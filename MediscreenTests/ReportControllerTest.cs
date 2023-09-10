using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using RiskReportService.Contracts;
using RiskReportService.Controllers;
using RiskReportService.Models;
using Xunit;

public class ReportControllerTests
{
    [Fact]
    public async Task GenerateRiskReport_ReturnsReport_WhenPatientExists()
    {
        // ARRANGE
        var patientId = 1;
        var patient = new PatientViewModel
        {
            FirstName = "Mickael",
            LastName = "Jordan",                     // => PatientName = Mickael Jordan
            DateOfBirth = new DateTime(1963, 2, 17), // => Age = 60
            Sex = 'M'
        };

        // Mock the dependencies
        var ageCalculator = new Mock<IAgeCalculator>();
        ageCalculator.Setup(a => a.CalculateAge(It.IsAny<DateTime>())).Returns(60); // Set the expected age

        var triggerTermsFinder = new Mock<ITriggerTermsFinder>();
        triggerTermsFinder.Setup(t => t.CountTriggerTerms(patientId)).ReturnsAsync(new TriggerTermList
        {
            TriggersCount = 2, // Set the expected trigger terms count
            TriggerTerms = new List<string> { "Cholesterol", "Antibodies" } // Set the expected trigger terms
        });

        var diabetesRiskLevelFinder = new Mock<IDiabetesRiskLevelFinder>();
        diabetesRiskLevelFinder.Setup(d => d.DetermineRiskLevel(2, 60, 'M')).ReturnsAsync(new string("Borderline")); // Set the expected risk level

        // Set the response to the GetAsync($"patients/{patientId}") request, that returns the specified patient
        var successfulPatientResponse = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(JsonConvert.SerializeObject(patient))
        };

        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(successfulPatientResponse);

        var httpClient = new HttpClient(handler.Object);

        var httpClientFactory = new Mock<IHttpClientFactory>();
        httpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(httpClient);

        var controller = new ReportController(httpClientFactory.Object, ageCalculator.Object, triggerTermsFinder.Object, diabetesRiskLevelFinder.Object);

        // ACT
        var result = await controller.GenerateRiskReport(patientId);

        // ASSERT
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var report = Assert.IsType<Report>(okResult.Value);
        Assert.Equal("Mickael Jordan", report.PatientName);
        Assert.Equal(60, report.Age); 
        Assert.Equal('M', report.Sex);
        Assert.Equal("Borderline", report.RiskLevel); 
        Assert.Equal(2, report.triggerTermList.TriggersCount); 
        Assert.Contains("Cholesterol", report.triggerTermList.TriggerTerms);
        Assert.Contains("Antibodies", report.triggerTermList.TriggerTerms);
    }
}



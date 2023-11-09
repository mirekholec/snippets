public void GetErrorFromMessage_ErrorMessage_Error()
{
    string errorMessage = "chybová zpráva";
    PrivateObject sut = new PrivateObject(typeof(RegistrationService), new RegistrationRepositoryDummy());

    var result = (Error)sut.Invoke("GetErrorFromMessage", errorMessage);

    result.Should().NotBeNull();
    result.Messages.Should().HaveCount(1);
    result.Messages[0].Should().Be(errorMessage);
}
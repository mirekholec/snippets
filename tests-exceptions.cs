[Fact]
public void Storno_GuidIsNotValid_Exception()
{
    var mock = new Mock<IRegistrationRepository>();

    RegistrationService sut = new RegistrationService(mock.Object);

    // verze fluent assertions
    Action act = () => sut.Storno("invalid guid");
    act.Should().Throw<Exception>();

    // verze assert
    Assert.ThrowsAny<Exception>(() => sut.Storno("invalid guid"));
}
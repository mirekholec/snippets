var controller = new OrderController(
    _orderServiceMock.Object,
    _basketServiceMock.Object,
    _identityParserMock.Object);

controller.ControllerContext.HttpContext = _contextMock.Object;
var actionResult = await orderController.Detail(fakeOrderId);

var viewResult = Assert.IsType<ViewResult>(actionResult);
Assert.IsAssignableFrom<Order>(viewResult.ViewData.Model);
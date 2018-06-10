$(document).ready(function () {

    var x = 0;
    var s = "";
    console.log("Hello world");

    var theForm = $("#theForm");
    theForm.hide();

    var button = $("#buyButton");

    button.on("click", function () {
        console.log("Test");
    });

    var ProductInfo = $(".product-props li");
    ProductInfo.on("click", function () {
        console.log("You clicked on " + $(this).text());
    });

});

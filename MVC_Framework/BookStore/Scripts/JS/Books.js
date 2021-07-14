//const { Dropdown } = require("bootstrap");

function AddToCart(bookId) {

    var addToCartId = "addtoCartBtn-".concat(bookId);
    var addToWishId = "wishlistBtn-".concat(bookId);
    var addedToCart = "addedtocartBtn-".concat(bookId);

    if (sessionStorage.getItem("token") == null) {
        window.location.href = 'https://localhost:44380/Users/Login';
    } else {
        var requestObject = {};
        requestObject.UserId = 1;
        requestObject.BookId = bookId;
        requestObject.Quantity = 1;
        console.log(JSON.stringify(requestObject));
        $.ajax({
            type: "POST",
            url: 'https://localhost:44380/Books/AddToCart',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem("token")
            },
            data: JSON.stringify(requestObject),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                //Onclick AddToCart button hide AddToCart button
                var AddToCartButton = document.getElementById(addToCartId);
                AddToCartButton.style.display = "none";

                //Onclick AddToCart button hide WishList button
                var AddToWishListButton = document.getElementById(addToWishId);
                AddToWishListButton.style.display = "none";

                //Onclick AddToCart button show AddedToCart button
                var AddedToCartButton = document.getElementById(addedToCart);
                AddedToCartButton.style.display = "block"
                // alert("Data has been added successfully.");  

            },
            error: function () {
                console.log("Error while inserting data");
            }
        });
    }
}

function AddToWishList(bookId) {
    var addToCartId = "addtoCartBtn-".concat(bookId);
    var addToWishId = "wishlistBtn-".concat(bookId);
    var addedToWishList = "addedtocartBtn-".concat(bookId);
    if (sessionStorage.getItem("token") == null) {
        window.location.href = 'https://localhost:44380/Users/Login';
    } else {
        var requestObject = {};
        requestObject.UserId = 1;
        requestObject.BookId = bookId;
        requestObject.WishListQuantity = 1;
        console.log(JSON.stringify(requestObject));
        $.ajax({
            type: "POST",
            url: 'https://localhost:44380/Books/AddToWishList',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem("token")
            },
            data: JSON.stringify(requestObject),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {


            },
            error: function () {
                console.log("Error while inserting data");
            }
        });
    }
}

function PlaceOrderbtn() {
    var PlaceOrderButton = document.getElementById("takeinput1");
    PlaceOrderButton.style.display = "block";
}

function Continuebtn() {
    var ContinueButton = document.getElementById("OrderBooks");
    ContinueButton.style.display = "block";
}

function Checkoutbtn() {
    var requestObject = {};
    requestObject.UserId = 1;
    console.log(JSON.stringify(requestObject));
    if (sessionStorage.getItem("token") == null) {
        window.location.href = 'https://localhost:44380/Users/Login';
    } else {

        $.ajax({
            type: "POST",
            url: 'https://localhost:44380/Cart/Checkout',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem("token")
            },
            data: JSON.stringify(requestObject),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                //Success 
            },
            error: function () {
                console.log("Error while inserting data");
            }
        });

        window.location.href = 'https://localhost:44380/Order/Order';

    }
}

function DropdownOpenClose() {
    var Dropdowninout = document.getElementById("dropdownmenu");

    if (Dropdowninout.style.display == "none") {
        Dropdowninout.style.display = "block";
    }
    else {
        Dropdowninout.style.display = "none";
    }
}


function CartBooks() {
    if (sessionStorage.getItem("token") == null) {
        window.location.href = 'https://localhost:44380/Users/Login';
    } else {

        var settings = {
            async: true,
            crossDomain: true,
            type: "GET",
            url: 'https://localhost:44380/Cart/AllCartBooks',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem("token")
            },
            dataType: "json",
        }

        $.ajax(settings).done(function (response) {
            console.log(response);
            $("#BookBody2").html(response);
        });

    }
}


$('#ToCart').click(function () {
    /*$.ajax({
        type: "GET",
        url: 'https://localhost:44380/Cart/AllCartBooks',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + sessionStorage.getItem("token")
        },
        dataType: "json",
        success: function (response) {
            //Success 
            console.log("success: " + response);
            $("#BookBody2").html(response);
        },
        error: function (response) {
            console.log(response);
            console.log("Error while inserting data");
        }
    });*/


    //var id = $(val).data('assigned-id');
    //console.log("id=>", val)
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": "https://localhost:44380/Cart/AllCartBooks",
        "method": "GET",
        "headers": {
            "content-type": "application/json",
            "authorization": "Bearer " + sessionStorage.getItem("token"),
        }
    }

    $.ajax(settings).done(function (response) {
        console.log(response)
        $("#BookBody2").html(response);
    });

})
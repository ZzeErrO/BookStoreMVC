const { Dropdown } = require("bootstrap");

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
                'Authentication': 'Bearer ' + sessionStorage.getItem("token")
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
                alert("Error while inserting data");
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
            data: JSON.stringify(requestObject),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {


            },
            error: function () {
                alert("Error while inserting data");
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
            data: JSON.stringify(requestObject),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                //Success 
            },
            error: function () {
                alert("Error while inserting data");
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

function AddToCart(bookId) {

    var addToCartId = "addtoCartBtn-".concat(bookId);
    var addToWishId = "wishlistBtn-".concat(bookId);
    var addedToCartId = "addedtocartBtn-".concat(bookId);
    var addedToWishlistId = "addedtowishlistBtn-".concat(bookId);

    if (sessionStorage.getItem("JwtToken") == null) {
        window.location.href = 'https://localhost:44301/Users/Login';
    } else {
        var requestObject = {};
        requestObject.UserId = 1;
        requestObject.BookId = bookId;
        requestObject.Quantity = 1;
        console.log(JSON.stringify(requestObject));
        $.ajax({
            type: "POST",
            url: 'https://localhost:44301/Books/AddToCart',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem("JwtToken")
            },
            data: JSON.stringify(requestObject),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
               
                var AddToCartButton = document.getElementById(addToCartId);
                AddToCartButton.style.display = "none";

               
                var AddToWishListButton = document.getElementById(addToWishId);
                AddToWishListButton.style.display = "none";

               
                var AddedToCartButton = document.getElementById(addedToCartId);
                AddedToCartButton.style.display = "block";

                var AddedToWishlistButton = document.getElementById(addedToWishlistId);
                AddedToWishlistButton.style.display = "none";
                  

            },
            error: function () {
                alert("Error while inserting data");
            }
        });

    }
}

function WishlistToCart(bookId) {

    var addToCartId = "addtoCartBtn-".concat(bookId);
   

    if (sessionStorage.getItem("JwtToken") == null) {
        window.location.href = 'https://localhost:44301/Users/Login';
    } else {
        var requestObject = {};
        requestObject.UserId = 1;
        requestObject.BookId = bookId;
        requestObject.Quantity = 1;
        console.log(JSON.stringify(requestObject));
        $.ajax({
            type: "POST",
            url: 'https://localhost:44301/Books/AddToCart',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem("JwtToken")
            },
            data: JSON.stringify(requestObject),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                //Onclick AddToCart button hide AddToCart button
                var AddToCartButton = document.getElementById(addToCartId);
                AddToCartButton.style.display = "none";

                

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
    if (sessionStorage.getItem("JwtToken") == null) {
        window.location.href = 'https://localhost:44301/Users/Login';
    } else {
        var requestObject = {};
        requestObject.UserId = 1;
        requestObject.BookId = bookId;
        requestObject.WishListQuantity = 1;
        console.log(JSON.stringify(requestObject));
        $.ajax({
            type: "POST",
            url: 'https://localhost:44301/Books/AddToWishList',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem("JwtToken")
            },
            data: JSON.stringify(requestObject),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                //Onclick AddToWishList button hide AddToCart button
                var AddToCartButton = document.getElementById(addToCartId);
                AddToCartButton.style.display = "none";

                //Onclick AddToWishList button hide WishList button
                var AddToWishListButton = document.getElementById(addToWishId);
                AddToWishListButton.style.display = "none";

                
                var AddedToCartButton = document.getElementById(addedToWishList);
                AddedToCartButton.style.display = "block";

                
               

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
    if (sessionStorage.getItem("JwtToken") == null) {
        window.location.href = 'https://localhost:44301/Users/Login';
    } else {
        $.ajax({
            type: "POST",
            url: 'https://localhost:44301/Cart/Placeorder',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem("JwtToken")
            },
            data: JSON.stringify(requestObject),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                window.location = '../Order/Orderconfirm'
            },
            error: function () {
                alert("Wrong input data");
            }
        });
    }
}
function CartButton() {
    if (sessionStorage.getItem("JwtToken") == null) {
        window.location.href = 'https://localhost:44301/Users/Login';
    } else {
        window.location.href = 'https://localhost:44301/Cart/CartBooks';
}


function CartDeletebtn() {
    var requestObject = {};
    requestObject.UserId = 1;
    console.log(JSON.stringify(requestObject));
    if (sessionStorage.getItem("JwtToken") == null) {
        window.location.href = 'https://localhost:44301/Users/Login';
    } else {
        $.ajax({
            type: "POST",
            url: 'https://localhost:44301/Cart/Placeorder',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem("JwtToken")
            },
            data: JSON.stringify(requestObject),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                window.location = '../Cart/CartBooks'
            },
            error: function () {
                alert("Wrong input data");
            }
        });
    }
}



    


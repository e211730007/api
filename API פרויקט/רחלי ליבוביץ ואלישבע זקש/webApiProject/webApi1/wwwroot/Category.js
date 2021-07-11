
function getcategory() {
    getProduct();
    fetch("api/Category")
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error("status Code is:" + response.status);
            }
        })
        .then(data => {
            console.log(data);
            data.forEach(c => drowCategory(c))
        });
}


function drowCategory(category) {
    p = document.getElementById("temp-category");
    var clonProduct = p.content.cloneNode(true);
    clonProduct.querySelector(".OptionName").innerText = category.categoryName;
    clonProduct.querySelector("input").addEventListener("click", () => {
        getProductByCategory(category)
    });
    document.getElementById("filters").appendChild(clonProduct);
}

function getProductByCategory(category) {
    fetch("api/Product/" + category.categoryId)
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error("status Code is:" + response.status);
            }
        })
        .then(data => {
            Empty();
            console.log(data);
            data.forEach(p => drowProducts(p))
        })
}

function getProduct() {
    fetch("api/Product/")
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error("status Code is:" + response.status);
            }
        })
        .then(data => {
            Empty();
            console.log(data);
            data.forEach(p => drowProducts(p))
        })
}

function drowProducts(product) {
    var url = "./pictures/";
    p = document.getElementById("temp-card");
    var clonProduct = p.content.cloneNode(true);
    clonProduct.querySelector(".description").innerText = product.description;
    clonProduct.querySelector(".name").innerText = product.productName;
    clonProduct.querySelector(".price").innerText = product.price + ' ' + 'ש"ח ';
    clonProduct.querySelector(".img-w").src = url + product.imageName;

    clonProduct.querySelector("button").addEventListener("click", () => {
        addToCart(product)
    });
    document.getElementById("PoductList").appendChild(clonProduct);
}


function Empty() {
    document.getElementById("PoductList").innerHTML ="";
}

var cart=[];
//sessionStorage.setItem("cart", null)
//sessionStorage.setItem("count",0)
//sessionStorage.setItem("price", 0)

function addToCart(product)
{
    var tmp = 0;
    var p = [];
    var i = 0;
    for (i = 0; i < cart.length; i++)
    {
        if (cart[i].p.productId == product.productId)
        {
            tmp = 1;
            cart[i].c = cart[i].c + 1;
            break;
        }
    }
    if (tmp == 0) {
        cart.push({ "p": product, "c": 1 });
    } 


    sessionStorage.setItem("cart", JSON.stringify(cart));
    count = JSON.parse(sessionStorage.getItem("count"));
    count1 = count + 1;
    sessionStorage.setItem("count", JSON.stringify(count1));
    price = JSON.parse(sessionStorage.getItem("price"));
    price1 = price + product.price;
    sessionStorage.setItem("price", JSON.stringify(price1));
    document.getElementById("ItemsCountText").innerText = count1.toString();

}  
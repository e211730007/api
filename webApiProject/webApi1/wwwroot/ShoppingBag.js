
var products = JSON.parse(sessionStorage.getItem("cart"));
window.addEventListener("load", (a) => { drowList(products) });

function drowList() {
    var products = JSON.parse(sessionStorage.getItem("cart"));

    count = JSON.parse(sessionStorage.getItem("count"));
    document.getElementById("itemCount").innerHTML = count;
    document.getElementById("totalAmount").innerHTML = JSON.parse(sessionStorage.getItem("price"));
    products.forEach(data => { getUserOrders(data.p, data.c) })
}

function getUserOrders(product, count) {
    let tmp = products.findIndex(pr => { return (pr.p).productId == product.productId });
    var url = "./pictures/";
    p = document.getElementById("temp-row");
    var clonProduct = p.content.cloneNode(true);
    clonProduct.querySelector(".image").style.backgroundImage = "url(pictures/" + product.imageName + ")";
    clonProduct.querySelector(".itemName").innerText = product.productName;
    clonProduct.querySelector(".itemNumber").innerText = products[tmp].c;
    clonProduct.querySelector(".price").innerText = count * product.price;
    clonProduct.getElementById("delete").addEventListener("click", () => {
        deleteProduct(product, count)
    });
    document.getElementById("tbody").appendChild(clonProduct)
}

function Empty() {
    document.getElementById("tbody").innerHTML = "";
}

function deleteProduct(product, count) {
    let tmp = products.findIndex(pr => { return (pr.p).productId == product.productId });
    if (products[tmp].c > 1)
        products[tmp].c -= 1;
    else
        products.splice(tmp, 1);


    let cart1 = JSON.stringify(products);
    sessionStorage.setItem("cart", cart1);
    count = JSON.parse(sessionStorage.getItem("count"));
    count1 = count - 1;
    sessionStorage.setItem("count", JSON.stringify(count1));
    price = JSON.parse(sessionStorage.getItem("price"));
    price1 = price - product.price;
    sessionStorage.setItem("price", JSON.stringify(price1))

    Empty();
    drowList();
}

function placeOrder() {

    let order = {
        OrderDate: new Date(),
        OrderSum: JSON.parse(sessionStorage.getItem("price")),
        UserId: JSON.parse(sessionStorage.getItem("user")).userId,
        OrderItem: []
    }

    products.forEach((val) => {
        order.OrderItem.push({
            OrderItemId: 0,
            ProductId: val.p.productId,
            Quantity: val.c
        })
    })

    fetch("api/Orders", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json; charset=utf-8'
        },
        body: JSON.stringify(order),
    }).then(response => {
        if (response.ok) {
            return response.json();
        } else {
            throw new Error("status Code is:" + response.status);
        }
    }).then(data => {
            alert(" הזמנה בוצעה בהמון סיעתא דשמיא ותיכך תקבלה תתאזר בסבלנות מספר ההזמנה הוא!!! " + data);
    }).catch(error => { console.log(error); });
}







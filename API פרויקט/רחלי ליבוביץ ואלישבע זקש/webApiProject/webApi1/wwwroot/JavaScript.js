
function b() {
    fetch("api/User").then(Response => Response.text()).
        then(result => document.getElementById("div1").innerText = result)
        .catch((error) => { console.log(error) });
}

function loggin() {
    let user = {
        Email: document.getElementById("Email").value,
        Password: document.getElementById("Password").value
    }
    fetch("api/User/"+ user.Email+"/" + user.Password)
        .then(response => {
            if (response.ok) {
                alert("עקרונית אתה יכול להכנס");
                return response.json();
            } else {
                throw new Error("status Code is:" + response.status);
            }
        })
        .then(data => {
            sessionStorage.setItem('user', JSON.stringify(data));
            alert("שלום " + data.firstName);
            window.location.href = ("update.html");
            //console.log('hello to:', data.FirstName + ' ' + data.LastName);
        })
}



function e()
    {
        document.getElementById("div3").style.display = "block"
}


function openUpdate() {
    document.getElementById("update").style.display = "block";
}

function upDate() {
    let User = {
        Email: document.getElementById("email").value,
        LastName: document.getElementById("lastname").value,
        FirstName: document.getElementById("firstname").value,
        Password: document.getElementById("password").value,

    };
    var oldUser = JSON.parse(sessionStorage.getItem('user'));

    fetch("api/User/" + oldUser.userId , {
        method: "PUT",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(User),
    }).then(response => {
        if (response.ok) {
            alert(" עדכנו את הפרטים");
        }
        else throw new Error("כתובת לא נמצאת");
    }).catch(error => { console.log(error); });

}

function newUser() {


    let user = {
        Password: document.getElementById("Password1").value,
        FirstName: document.getElementById("FirstName").value,
        Email: document.getElementById("Email1").value,
        LastName: document.getElementById("LastName").value,
    }

    fetch("api/User", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(user),
    }).then(response => {
        if (response.ok)
            alert("נרשמת בהצלחה!!!");
        else {
            response.json().then(error => alert(JSON.stringify(error.errors)))}
    }).catch(error => {
        console.log(error);
    });
    
    
}
function Create(controller, data) {
    $.ajax({
        type: "POST",
        url: "/" + controller + "/Create",
        data: data,
        cache: false, 
        success: function (response) {
            if (response > 0) {
                console.log("success: " + response); 
                SAlert("Guardar", "Se Guardo el registro con Exito", "success", "OK");
            }
            else {
                console.log("error: " + response);
                SAlert("Error", "No se Guardo el Registro", "error", "OK");
            }
        },
        error: function (response) {
            console.log("error: " + response);
            SAlert("Error", "No se Proceso la Solicitud de Guardar", "Error", "OK");
        }
        
    });
}

//combo 
function GetDropDownData() {
    $.ajax({
        type: "GET",
        url: "https://aplicacion-web-de-emergencias.firebaseio.com/",
        //        data: '{name: "abc" }',
        data: '{rol: "NombreRol" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function () {
                // $(".myDropDownLisTId").append($("<option     />").val(this.KeyName).text(this.ValueName));
                $(".myDropDownLisTId").append($("<option     />").val(this.KeyName).text(this.ValueName));
            });
        },
        failure: function () {
            alert("Failed!");
        }
    });
}
//Obtener la lista 

function getListas(controller) {
    
    //function getLists(controller) {

    $.ajax({
        type: "GET",
        url: "/" + controller + "/ListAdministracion",
        //url: "/" + controller + "/ListAdmins",
        //data: sel.value,
        cache: false,
        success: function (data) {
            //console.log(response);
            // var data = respond;
            var html = "";

            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Nombres + "</td>";
                //html += "<td>" + item.Apellidos + "</td>"
                html += "<td>" + item.Telefono + "</td>"
                html += "<td>" + item.Email + "</td>"
                html += "<td>" + item.Rol + "</td>"
                html += "<td >";
                html += "      <a class='btn btn-success'  href='./Edit" + "?id=" + item.IDAdmin + "'>Editar</a>";
                html += " <button class='btn btn-danger' onclick = " + "Delete('" + item.IDAdmin + "')" + " > Eliminar</button >";
                //Detalle
                html += "<td style='height:auto; width:240px'><a class='btn btn-success' onClick='verDetalle(" + item.IDAdmin + ")' data-toggle='modal' data-target='#exampleModalCenter' >Ver</a>";
                //html += "      <a class='btn btn-danger' onClick='Delete(" + item.AdminID + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";

            });
            $('#body').append(html);

        },
        error: function (response) {

        }
    });
}

function Delete(IDAdmin) {
    var resp = confirm("Seguro que quieres eliminar");
    if (resp) {
        $.ajax({
            url: "/Admi/Delete/" + IDAdmin,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (respuesta) {
                if (respuesta > 0) {
                    alert("Eliminado Exitosamente. Exito");
                    getLists();
                }
                else {
                    alert("No se realizo el proceso");
                }
            }


        });
    }

}
//Obtner detalles
function verDetalle(IDAdmin) {
    $.ajax({
        //url: "/" + url + "/getPelicula/" + IDAdmin,
        url: "/" + url + "/getAdmin/" + IDAdmin,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        //dataType: "json",
        success: function (data) {
            $("#_IDAdmin").text(data.IDAdmin);
            $("#_Nombres").text(data.Nombres);
            $("#_Apellidos").text(data.Apellidos);
            $("#_UserName").text(data.Telefono);

        },
        error: function (error) {
            alert('Ocurrio un error');
        }

    });
}



//Modificar Administrador
function Edit(controller, data, IDAdmin) {
    $.ajax({
        type: "POST",
        url: "/" + controller + "/Edit/" + IDAdmin,
        data: data,
        cache: false,
        success: function (response) {
            if (response > 0) {
                console.log("success: " + response);
                SAlert("Editar", "Registro Modificado", "success", "OK");
            }
            else {
                alert("Accion Invalida");
            }
        },
        failure: function (response) {
            console.log("error: " + response);
            alert(response);
        }
    });
}

//LOGIN
function logi(controller) {

    //function getLists(controller) {

    $.ajax({
        type: "GET",
        url: "/" + controller + "/Logi",
        //url: "/" + controller + "/ListAdmins",
        //data: sel.value,
        cache: false,
        success: function (data) {
            //console.log(response);
            // var data = respond;
            var html = "";

            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Email + "</td>"
                html += "<td>" + item.Rol + "</td>"
                html += "<td >";
                //html += "      <a class='btn btn-success'  href='./Admi/Edit" + "?id=" + item.IDAdmin + "'>Editar</a>";
                //html += " <button class='btn btn-danger' onclick = " + "Delete('" + item.IDAdmin + "')" + " > Eliminar</button >";
                //html += "      <a class='btn btn-danger' onClick='Delete(" + item.AdminID + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";

            });
            $('#body').append(html);

        },
        error: function (response) {

        }
    });
}
//LOGIN
//obtener
//function getUser(controller) {

//    $.ajax({
//        type: "GET",
//        url: "/" + controller + "/get" + controller,
//        cache: false,
//        success: function (data) {

//            //console.log(response);
//            // var data = respond;  
//            var html = "";

//            $.each(data, function (key, item) {
//                html += "<tr>";
//                html += "<td>" + item.Name + "</td>";
//                html += "<td>" + item.LastName + "</td>"
//                html += "<td>" + item.Phone + "</td>"
//                html += "<td>" + item.Email + "</td>"
//                html += "<td>" + item.State + "</td>"
//                html += "<td >";
//                html += " <a class='btn btn-success'  href='/Admin/Edit" + "?id=" + item.UserID + "'>  Validar " + "<i class='fas fa-user-cog'></i>" + "</a>";
//                html += "</td>";
//                html += "</tr>";

//            });
//            $('#body').append(html);

//        },
//        error: function (response) {

//        }
//    });
//}//


function SAlert(title, msg, icon, btns) {
    Swal.fire({
        title: title,
        text: msg,
        icon: icon,
        confirmButtonText: btns
    })
}
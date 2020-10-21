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


// Funcion Modificar Usuario 
function Edit(controller, data, HospitalID) {
    $.ajax({
        type: "POST",
        url: "/" + controller + "/Edit/" + HospitalID,
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
//llenar combo
function GetDropDownData() {
    $.ajax({
        type: "POST",
        url: "https://aplicacion-web-de-emergencias.firebaseio.com/",
        //        data: '{name: "abc" }',
        data: '{rol: "NombreRol" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(data)
            {
                $.each(data, function (){
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

function getListUsuarioH(controller) {

    //function getLists(controller) {

    $.ajax({
        type: "GET",
        url: "/" + controller + "/ListAUsuario",
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
                html += "      <a class='btn btn-success'  href='./Edit" + "?id=" + item.HospitalID + "'>Editar</a>";
                html += " <button class='btn btn-danger' onclick = " + "Delete('" + item.HospitalID + "')" + " > Eliminar</button >";
                //Detalle
                html += "<td style='height:auto; width:240px'><a class='btn btn-success' onClick='verDetalle(" + item.HospitalID + ")' data-toggle='modal' data-target='#exampleModalCenter' >Ver</a>";
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
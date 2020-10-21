function MyonLoad() {
    cargar_OpcionesDesdeFirebase2()

}
function cargar_OpcionesDesdeFirebase2() {
    refRol = firebase.database().ref().child("rol");
    refRol.on("value", function (snap) {
        let datos = snap.val();
        console.log(datos)

        for (let key in datos) {
            let arrayFirebase = datos[key].NombreRol
            console.log(arrayFirebase);
            addOptions("opciones-de-firebase2", arrayFirebase);
        }
    });
}
//ruta de opcines al select
function addOptions(domElement, arrayFirebase) {
    var select = document.getElementByName(domElement)[0];
    // for (value in arrayFirebase) {
    var option = document.createElement("option");
    option.text = arrayFirebase;
    select.add(option);
    //}
}
//mas opciones 

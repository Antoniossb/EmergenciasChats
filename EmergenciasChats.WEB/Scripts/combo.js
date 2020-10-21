// var db = firebase.firestore(); //Mando a llamar la instancia de base de datos

//// var selected_item = document.getElementById('select_empresa');//Se llama el selected   el rol es nombre de la tabla 
// var selected_item = document.getElementById('rol');//Se llama el selected   el rol es nombre de la tabla 
//    selected_item.innerHTML = '';
//    selected_item.innerHTML += `
//            <option value="0" selected>Selecciona el Rol al que perteneces</option>

//            //Agrego un option por default
//            ` 
//    db.collection("company").onSnapshot((querySnapshot) => { //Se llaman los datos
//            querySnapshot.forEach((doc) => {
//                // console.log(`${doc.id} => ${doc.data().name}`);
//                //llamo el nombre de rol
//                console.log(`${doc.id} => ${doc.data().name}`);
//            selected_item.innerHTML += `
//            <option value="${doc.id}">${doc.data().name}</option>. 
//            `
//                //Aquí agrego los options de acuerdo a la base de datos.
//        });
//    });
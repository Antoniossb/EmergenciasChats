const form__padre = document.getElementById('form__padre');
const form__input = document.querySelectorAll('#form__padre input');

const expresiones = {
    //caracteres de cada campo
	Nombres: /^[a-zA-ZÀ-ÿ\s]{4,40}$/, 
	Apellidos: /^[a-zA-ZÀ-ÿ\s]{4,40}$/,
	Sexo: /^[a-zA-ZÀ-ÿ\s]{4,40}$/,
	Dui: /^[a-zA-ZÀ-ÿ\s]{4,40}$/,
	//Telefono: /^[a-zA-ZÀ-ÿ\s]{4,40}$/,
	Direccion: /^[a-zA-ZÀ-ÿ\s]{4,40}$/,
	NameUser: /^[a-zA-ZÀ-ÿ\s]{4,40}$/,
	Password: /^.{4,12}$/,
	Email: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/
}

const campos = {
    //campos  null
    //Nombres: false,
   // Apellidos: false, 
    //Sexo: false,
    //Dui: false,
    //Telefono: false,
    //Direccion: false,
    //NameUser: false,
    //Password: false,
    //Email: false
}

const validarForm = (e) => {
    switch (e.target.Nombres) {
        case "Nombres":
            validarInput(expresiones.Nombres, e.target, 'Nombres');
        break;
        case "Apellidos":
            validarInput(expresiones.Apellidos, e.target, 'Apellidos');
            break;
        case "Sexo":
            validarInput(expresiones.Sexo, e.target, 'Sexo');
            break;
        case "Dui":
            validarInput(expresiones.Dui, e.target, 'Dui');
            break;
        //case "Telefono":
        //    validarInput(expresiones.Telefono, e.target, 'Telefono');
        //    break;
        case "Direccion":
            validarInput(expresiones.Direccion, e.target, 'Direccion');
            break;
        case "NameUser":
            validarInput(expresiones.NameUser, e.target, 'NameUser');
            break;
        case "Password":
            validarInput(expresiones.Password, e.target, 'Password');
        break;
        case "Email":
            validarInput(expresiones.Email, e.target, 'Email');
        break;
    }
}

const validarInput = (validacion, caja, campo) => {
    if(validacion.test(caja.value)){
        document.getElementById(`grupo__${campo}`).classList.remove('form__grupo-incorrecto');
        document.getElementById(`grupo__${campo}`).classList.add('form__grupo-correcto');
        document.querySelector(`#grupo__${campo} .form__input-error`).classList.remove('form__input-error-activo');
        campos[campo] = true;
    } else {
        document.getElementById(`grupo__${campo}`).classList.add('form__grupo-incorrecto');
        document.getElementById(`grupo__${campo}`).classList.remove('form__grupo-correcto');
        document.querySelector(`#grupo__${campo} .form__input-error`).classList.add('form__input-error-activo');
        campos[campo] = false;
    }
}

form__input.forEach((input) => {
    input.addEventListener('keyup', validarForm);
    input.addEventListener('blur', validarForm);
});

form__padre.addEventListener('submit', (e) => {
    e.preventDefault();
    
    const terminos = document.getElementById('terminos');
    if( campos.Nombres && campos.Apellidos && campos.Sexo && campos.Dui && campos.Direccion && campos.NameUser && campos.Password && campos.Email && terminos.checked){
        form__padre.reset();
        
        //El mensaje se agrega cuando los inputs estan correctos y luego se elimina durante 5 segundos
        document.getElementById('form__mensaje-exitoso').classList.add('form__mensaje-exitoso-activo');
        setTimeout(() => {
            document.getElementById('form__mensaje-exitoso').classList.remove('form__mensaje-exitoso-activo');
        }, 9000);
        
        document.querySelectorAll('.form__grupo-correcto').forEach((correcto) => {
			correcto.classList.remove('form__grupo-correcto');
		});
        
        document.getElementById('form__mensaje').classList.remove('form__mensaje-activo');
    } else {
        document.getElementById('form__mensaje').classList.add('form__mensaje-activo');
    }
    
});
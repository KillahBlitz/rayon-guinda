
//definicion de la ruta de la api
const URL = 'http://localhost:5263/api/';


//funciones para el usuario
//aqui estan las peticiones a la API relacionadas con el usuario (UsuarioController)
export function RegistroUsuario(usuario){
    //guardando datos de reguistro
    let data = { ApellidoPaterno: usuario.Apatern, ApellidoMaterno: usuario.Amatern, Nombres: usuario.Nombre, FechaNacimiento: usuario.FechaNac, CorreoInstitucional: usuario.Correo, Contraseña: usuario.Password}   
    
    //esto es lo que voy a devolver dependiendo el caso
    return fetch(URL+'registro', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }).then(data => data.json()) //entonces parseamos data a json que es la respuesta de la peticion
}

//funcion para iniciar sesion del usuario
export function LoginUsuario(usuario){
    let datos = {CorreoInstitucional: usuario.Correo, Contraseña: usuario.Password}

    //lo que voy a devolver dependiendo el caso que me regrese la peticion http
    return fetch(URL+'login', {
        method: 'POST', //donde el metodo POST es el que esta
        body: JSON.stringify(datos), //paso los datos en formato JSON
        headers: { //lo que mando en la peticion y en que formato
            'Content-Type': 'application/json'
        }
    })
    .then(data => data.json()) //entonces parseamos data a json que es la respuesta de la peticion
}

//funcion para recuperar el id del usuario por el correo
export function RecuperarIDuser(usuario){
    let correo = usuario.Correo;
    //llamar a la api en la funcion de devolver id del usuario
    return fetch(URL+'getid?CorreoInstitucional='+correo, {
        method: 'GET'
    }).then(response => response.json());
}

//funcion para recuperar los datos del usuario por el id
export function RecuperarUsuario(id){
    let idUsuario = id;
    return fetch(URL+'getusuario?id='+idUsuario, {
        method: 'GET'
    }).then(response => response.json());
}

//funcion para recupera los grupos del usuario por el id
export function RecuperarGruposUsuario(id){
    let idUsuario = id;
    return fetch(URL+'usergropus?id='+idUsuario, {
        method: 'GET'
    }).then(response => response.json());
}

//funcion para modificar los datos del usuario
export function ModificarUsuario(usuario){
    let data = { UserId: usuario.Id, ApellidoPaterno: usuario.Apatern, ApellidoMaterno: usuario.Amatern, Nombres: usuario.Nombre, FechaNacimiento: usuario.FechaNac, CorreoInstitucional: usuario.Correo, NumBoleta: usuario.NoBoleta }
    console.log(data);
    return fetch(URL+'cambiardatos', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }).then(data => data.json());
}

//funciones para los grupos
//aqui estan las peticiones a la API relacionadas con los grupos (GrupoController)

//funcion para recuperar un codigo unico de grupo
export function RecuperarCodigoGrupo(){
    return fetch(URL+'crearcodigogrupo', {
        method: 'GET'
    }).then(response => response.text());
}
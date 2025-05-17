
//definicion de la ruta de la api
const URL = 'http://localhost:5263/api/';




//funciones para el usuario
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
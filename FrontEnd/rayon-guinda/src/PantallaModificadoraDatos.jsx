import {Box, Center, FormControl, FormLabel, Heading, Input, Flex, Alert, Button, useToast } from '@chakra-ui/react';
import * as API from "./services/data";
import { useNavigate } from "react-router";
import { useState, useEffect } from 'react';


export function PantallaModificadoraDatos() {
    const [usuario, setUsuario] = useState({Id: '', Apatern:'', Amatern:'', Nombre:'', FechaNac:'', Correo:'', Password:'', NoBoleta:''});
    const idUsuario = localStorage.getItem('idUsuario');
    const navigate = useNavigate();

    //variables vizuales para el toast y el input de la contraseña
    const toast = useToast();
    const [mensajeError, setMensajeError] = useState('');

    //expresiones regulares para validar todos los datos
    const validarApellidos = /^[A-Za-z][a-z]+$/;
    const validarNombres = /^[A-Za-z][a-z]+( [A-Za-z][a-z]+)?$/;
    //const validarCorreo = /[a-zA-Z0-9~._%+|?!$#/={}^-]+@[alumno.ipn.mx]|[ipn.mx]/g;
    const validarContrasena = /^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,12}$/gm

    // Recuperar los datos del usuario al cargar el componente
    useEffect(() => {
    const id = localStorage.getItem("idUsuario");
    if (id) {
        API.RecuperarUsuario(id).then(data => {
        setUsuario({
            Id: id,
            Apatern: data.apellidoPaterno,
            Amatern: data.apellidoMaterno,
            Nombre: data.nombres,
            FechaNac: data.fechaNacimiento,
            Correo: data.correoInstitucional,
            NoBoleta: data.numBoleta,
            Password: data.password
        });
        });
    }
    }, []); // solo una vez al montar


    //funcion validadora de los datos
    function validarDatosySubirlos(e){
        console.log(usuario);
        e.preventDefault();
        const fecha = new Date(usuario.FechaNac);
        const anioNacimiento = fecha.getFullYear();
        const anioActual = new Date().getFullYear();
        const edad = anioActual - anioNacimiento;

        if(usuario.Apatern === '' || usuario.Amatern === '' || usuario.Nombre === '' || usuario.FechaNac === '' || usuario.Correo === '' || usuario.Password === '' || usuario.ConfirmarPassword === ''){
            setMensajeError("Todos los campos son obligatorios");
        }
        else if(!validarApellidos.test(usuario.Apatern) || !validarApellidos.test(usuario.Amatern)){
            setMensajeError("Los apellidos no pueden tener caracteres especiales");
            return;
        }
        else if( !validarNombres.test(usuario.Nombre)){
            setMensajeError("El nombre solo puede contener letras, solo se pueden ingresar dos nombres");
            return;
        }
//        else if(!validarCorreo.test(usuario.Correo)){
//            setMensajeError("El correo no es institucional");
//            return;           
//        }
        else if(!validarContrasena.test(usuario.Password) && (usuario.Password === usuario.ConfirmarPassword)){
            setMensajeError("Las contraseñas no coinciden o no tiene el formato correcto");
            return;           
        }
        else if(usuario.FechaNac === '' || edad < 14){
            setMensajeError("La fecha de nacimiento no es válida, recuerda que debes ser mayor de 14 años");
            return;
        }
        else{ 
            setMensajeError(''); // limpia el mensaje de error si todo va bien
            ModificarDatos();
        }
    }


    function volver(){
        navigate(`/PantallaEditarPerfil?id=${idUsuario}`);
    }

    function ModificarDatos(){
        API.ModificarUsuario(usuario)
            .then(response => {
                if (response === true) {
                    toast({ title: "Datos modificados correctamente", status: "success", duration: 3000, isClosable: true, position: "top" });
                    navigate(`/PantallaEditarPerfil?id=${idUsuario}`);
                } else {
                    toast({ title: "Error Inesperado", status: "error", duration: 3000, isClosable: true, position: "top" });
                }
            })
            .catch(() => {
                console.error("Error al modificar los datos");
                toast({
                    title: "Error al modificar los datos",
                    status: "error",
                    duration: 3000,
                    isClosable: true,
                    position: "top"
                });
            });
    }



    return(
    <>
        <Box bg="#4A0000" minHeight="100vh" width="100vw" overflow="hidden" m={0} p={0} fontFamily={"Open Sans"}>
            <Box mt='30px'>
                <Center>
                        <Box borderRadius='md' m='2%' width='40%' id='caja' bg='#ffffff3e' color='white'>
                            <Box textAlign='center'>
                                <Heading>Modificar Datos de la Cuenta</Heading>
                            </Box>
                            <Box padding='20px'>
                                <form id='Modificador-form' onSubmit={validarDatosySubirlos}>
                                    <FormControl mt='20px'>
                                        <Center>
                                            <FormLabel>Correo: {usuario.Correo}</FormLabel>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='10px'>
                                        <Center>
                                            <FormLabel>Apellido Paterno: </FormLabel>
                                            <Input type="text" id="Apatern" value={usuario.Apatern} bg='white' color='black' width='250px' mr='70px' onChange={(e) => setUsuario({...usuario, Apatern: e.target.value})}/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='10px'>
                                        <Center>
                                            <FormLabel>Apellido Materno: </FormLabel>
                                            <Input type="text" id="Amatern" value={usuario.Amatern} bg='white' color='black' width='250px' mr='75px' onChange={(e) => setUsuario({...usuario, Amatern: e.target.value})}/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='10px'>
                                        <Center>
                                            <FormLabel>Nombre(s): </FormLabel>
                                            <Input type="text" id="Nombre"  value={usuario.Nombre} bg='white' color='black' width='250px' mr='30px' onChange={(e) => setUsuario({...usuario, Nombre: e.target.value})}/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='10px'>
                                        <Center>
                                            <FormLabel>Fecha de nacimiento: </FormLabel>
                                            <Input type="date" id="Date" bg='white' color='black' width='250px' mr="95px" value={usuario.FechaNac} onChange={(e) => setUsuario({...usuario, FechaNac: e.target.value})}/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='10px'>
                                        <Center>
                                            <FormLabel>Numero de Boleta: </FormLabel>
                                            <Input type="text" id="boleta" value={usuario.NoBoleta} bg='white' color='black' width='250px' mr='80px' onChange={(e) => setUsuario({...usuario, NoBoleta: e.target.value})}/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='20px' mb='20px' color='yellow'>
                                        <FormLabel textAlign="center">{mensajeError}</FormLabel>
                                    </FormControl>
                                    <FormControl mt='3px'>
                                        <Center>
                                            <Button bgColor="#3c3c3c" color="white" variant='solid' position='absolute' width='30%' left="20px" _hover={{ bg: "#3c3c3c" }} onClick={volver}>Volver</Button>
                                            <Input type='submit' width='30%' id='Modificar' borderColor='teal' value='Cambiar Datos' left="180px" border='none' cursor='pointer' fontFamily={"Ubuntu"} bg='#3c3c3c'/>
                                        </Center>
                                    </FormControl>
                                </form>
                            </Box>
                        </Box>
                </Center>
            </Box>
        </Box>
    </>
    )
}
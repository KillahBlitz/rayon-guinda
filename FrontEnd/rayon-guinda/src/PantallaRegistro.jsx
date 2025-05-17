import {Box, Center, FormControl, FormLabel, Heading, Input, Flex, useToast, Alert } from '@chakra-ui/react';
import * as API from "./services/data";
import { useNavigate } from "react-router";
import { useState } from 'react'


export function PantallaRegistro(){
    const [usuario, setUsuario] = useState({Apatern:'', Amatern:'', Nombre:'', FechaNac:'', Correo:'', Password:'', ConfirmarPassword:''});
    const [mensajeError, setMensajeError] = useState('');
    
    const navigate = useNavigate();
    const toast = useToast();

    //expresiones regulares para validar todos los datos
    const validarApellidos = /^[A-Za-z][a-z]+$/;
    const validarNombres = /^[A-Za-z][a-z]+( [A-Za-z][a-z]+)?$/;
    const validarCorreo = /[a-zA-Z0-9~._%+|?!$#/={}^-]+@[alumno.ipn.mx]|[ipn.mx]/g;
    const validarContrasena = /^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,12}$/gm

    function cancelar(){
        navigate("/");
    }

    function registrar(e){
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
        else if(!validarCorreo.test(usuario.Correo)){
            setMensajeError("El correo no es institucional");
            return;           
        }
        else if(!validarContrasena.test(usuario.Password) && (usuario.Password === usuario.ConfirmarPassword)){
            setMensajeError("Las contraseñas no coinciden o no tiene el formato correcto");
            return;           
        }
        else if(usuario.FechaNac === '' || edad < 14){
            setMensajeError("La fecha de nacimiento no es válida, recuerda que debes ser mayor de 14 años");
            return;
        }
        else{ 
            API.RegistroUsuario(usuario)
            .then((result) => {
                if(result===true){
                    setMensajeError(''); // limpia el mensaje de error si todo va bien
                    const toastId = toast({ duration: 3000, isClosable: true, position: 'top',
                    render: () => (
                    <Center>
                        <Box p="6" bg="#4A0000" color="white" fontSize="xl" borderRadius="lg" boxShadow="xl" mt="200px" textAlign="center" minW="400px">
                            <strong>Registro exitoso</strong>
                            <br />
                            Tu cuenta ha sido creada correctamente.
                        </Box>
                    </Center>
                    )});
                    // Espera 3 segundos antes de redirigir
                    setTimeout(() => { toast.close(toastId); navigate("/");}, 3000);
                    return;
                }
                else{
                    alert("Ocurrio algun error inesperado");
                }
            });
        }
    }

    
    return(
    <>
        <Box bg="#4A0000" minHeight="100vh" width="100vw" overflow="hidden" m={0} p={0} fontFamily={"Open Sans"}>
            <Box mt='30px'>
                <Center>
                        <Box borderRadius='md' m='2%' width='40%' id='caja' bg='#ffffff3e' color='white'>
                            <Box textAlign='center'>
                                <Heading>Registrate</Heading>
                            </Box>
                            <Box padding='20px'>
                                <form id='register-form' onSubmit={registrar}>
                                    <Flex justifyContent="space-between">
                                        <FormControl mt='3px'>
                                            <FormLabel>Apellido Paterno:</FormLabel>
                                            <Input type="text" id="Apatern" placeholder="Apellido Paterno" bg='white' color='black' width='250px' mr='70px' onChange={event => setUsuario({...usuario, Apatern: event.target.value})}/>
                                        </FormControl>
                                        <FormControl>
                                            <FormLabel>Apellido Materno:</FormLabel>
                                            <Input type="text" id="Amatern" placeholder="Apellido Materno" bg='white' color='black' width='250px' onChange={event => setUsuario({...usuario, Amatern: event.target.value})}/>
                                        </FormControl>
                                    </Flex>
                                    <FormControl mt='3px'>
                                    <FormLabel>Nombre(s):</FormLabel>
                                        <Input type="text" id="Nombre" placeholder="Nombre(s)" bg='white' color='black' onChange={event => setUsuario({...usuario, Nombre: event.target.value})}/>
                                    </FormControl>
                                    <FormControl mt='3px'>
                                        <FormLabel>Fecha de nacimiento:</FormLabel>
                                        <Input type="date" id="Date" bg='white' color='black' width='200px' onChange={event => setUsuario({...usuario, FechaNac: event.target.value})}/>
                                    </FormControl>
                                    <FormControl mt='3px'>
                                        <FormLabel>Correo:</FormLabel>
                                        <Input type="text" id="Correo" placeholder="Escribe tu correo aquí" bg='white' color='black' onChange={event => setUsuario({...usuario, Correo: event.target.value})}/>
                                    </FormControl>
                                    <FormControl mt='3px'>
                                        <FormLabel>Contraseña:</FormLabel>
                                        <Input type="password" id="Password" placeholder="Escribe tu contraseña aquí" bg='white' color='black' onChange={event => setUsuario({...usuario, Password: event.target.value})}/>
                                    </FormControl>
                                    <FormControl>
                                        <FormLabel fontSize='12px' ml='5px' mt='2px'>La contraseña debe tener al menos una mayuscula y un numero, debe tener entre 8 a 12 caracteres</FormLabel>
                                    </FormControl>
                                    <FormControl mt='3px'>
                                        <FormLabel>Confirma tu Contraseña:</FormLabel>
                                        <Input type="password" id="ConfirmPassword" placeholder="Confirma tu contraseña aquí" bg='white' color='black' onChange={event => setUsuario({...usuario, ConfirmarPassword: event.target.value})}/>
                                    </FormControl>
                                    <FormControl mt='20px' mb='20px' color='yellow'>
                                        <FormLabel textAlign="center">{mensajeError}</FormLabel>
                                    </FormControl>
                                    <FormControl mt='3px'>
                                        <Center>
                                            <Input type='button' mt='3px' width='30%' id='cancelar' borderColor='teal' value='Cancelar' border='none' cursor='pointer' fontFamily={"Ubuntu"} bg='#7c0015' onClick={() => cancelar()}/>
                                            <Input type='submit' ml='200px' mt='3px' width='30%' id='registro' borderColor='teal' value='Registrarse' border='none' cursor='pointer' fontFamily={"Ubuntu"} bg='#7c0015'/>
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
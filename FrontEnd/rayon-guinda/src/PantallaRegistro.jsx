import {Box, Center, FormControl, FormLabel, Heading, Input, Flex } from '@chakra-ui/react';
import { useNavigate } from "react-router";
import { useState } from 'react'


export function PantallaRegistro(){
    const [usuario, setUsuario] = useState({Apatern:'', Amatern:'', Nombre:'', FechaNac:'', Correo:'', Password:'', ConfirmarPassword:''});
    const navigate = useNavigate();

    //expresiones regulares para validar todos los datos
    const ParaApellidos = /^[A-Za-z][a-z]+$/;
    const ParaNombres = /^[A-Za-z][a-z]+( [A-Za-z][a-z]+)?$/;

    function cancelar(){
        navigate("/");
    }

    function registrar(e){
        e.preventDefault();
        if(!ParaApellidos.test(usuario.Apatern).length < 20 || !ParaApellidos.test(usuario.Amatern).length < 20){
            alert("Los apellidos deben empezar con mayuscula y no tener caracteres especiales");
            return;
        }
        else if(!ParaNombres.test(usuario.Nombre).length > 20){
             alert("El nombre solo puede contener letras, con un solo espacio opcional entre dos palabras.");
            return;
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
                                        <Input type="text" id="Apatern" placeholder="Nombre(s)" bg='white' color='black' onChange={event => setUsuario({...usuario, Nombre: event.target.value})}/>
                                    </FormControl>
                                    <FormControl mt='3px'>
                                        <FormLabel>Fecha de nacimiento:</FormLabel>
                                        <Input type="date" id="date" bg='white' color='black' width='200px' onChange={event => setUsuario({...usuario, FechaNac: event.target.value})}/>
                                    </FormControl>
                                    <FormControl mt='3px'>
                                        <FormLabel>Correo:</FormLabel>
                                        <Input type="text" id="Correo" placeholder="Escribe tu correo aquí" bg='white' color='black' onChange={event => setUsuario({...usuario, Correo: event.target.value})}/>
                                    </FormControl>
                                    <FormControl mt='3px'>
                                        <FormLabel>Contraseña:</FormLabel>
                                        <Input type="password" id="password" placeholder="Escribe tu contraseña aquí" bg='white' color='black' onChange={event => setUsuario({...usuario, Password: event.target.value})}/>
                                    </FormControl>
                                    <FormControl>
                                        <FormLabel fontSize='12px' ml='5px' mt='2px'>La contraseña debe tener al menos una mayuscula y un numero, debe tener entre 8 a 12 caracteres</FormLabel>
                                    </FormControl>
                                    <FormControl mt='3px'>
                                        <FormLabel>Confirma tu Contraseña:</FormLabel>
                                        <Input type="password" id="password" placeholder="Confirma tu contraseña aquí" bg='white' color='black' onChange={event => setUsuario({...usuario, ConfirmarPassword: event.target.value})}/>
                                    </FormControl>
                                    <br />
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
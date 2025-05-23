import {Box, Center, FormControl, FormLabel, Heading, Input, Flex, Alert, Button } from '@chakra-ui/react';
import * as API from "./services/data";
import { Form, useNavigate } from "react-router";
import { useState } from 'react'

export function PantallaEditarPerfil() {
    const [usuario, setUsuario] = useState({Apatern:'', Amatern:'', Nombre:'', FechaNac:'', Correo:'', Password:'', ConfirmarPassword:'', NoBoleta:''});
    const navigate = useNavigate();
    const idUsuario = localStorage.getItem('idUsuario');

    function volver(){
        navigate(`/PantallaPrincipal?id=${idUsuario}`);
    }

    return(
    <>
        <Box bg="#4A0000" minHeight="100vh" width="100vw" overflow="hidden" m={0} p={0} fontFamily={"Open Sans"}>
            <Button bgColor="#3c3c3c" color="white" variant='solid' position='absolute' top='20px' left='20px' width="120px" _hover={{ bg: "#3c3c3c" }} onClick={volver}>Volver</Button>
            <Box mt='30px'>
                <Center>
                        <Box borderRadius='md' m='2%' width='40%' id='caja' bg='#ffffff3e' color='white'>
                            <Box textAlign='center'>
                                <Heading>Datos de la Cuenta</Heading>
                            </Box>
                            <Box padding='20px'>
                                <form id='vizualizer-form'>
                                    <FormControl mt='20px'>
                                        <Center>
                                            <FormLabel>Correo: {usuario.Correo}</FormLabel>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='10px'>
                                        <Center>
                                            <FormLabel>Apellido Paterno: </FormLabel>
                                            <Input type="text" id="Apatern" placeholder={usuario.Apatern} bg='white' color='black' width='250px' mr='70px' isReadOnly/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='10px'>
                                        <Center>
                                            <FormLabel>Apellido Materno: </FormLabel>
                                            <Input type="text" id="Amatern" placeholder={usuario.Amatern} bg='white' color='black' width='250px' mr='75px' isReadOnly/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='10px'>
                                        <Center>
                                            <FormLabel>Nombre(s): </FormLabel>
                                            <Input type="text" id="Nombre" placeholder={usuario.Nombre} bg='white' color='black' width='250px' mr='30px' isReadOnly/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='10px'>
                                        <Center>
                                            <FormLabel>Fecha de nacimiento: </FormLabel>
                                            <Input type="date" id="Date" bg='white' color='black' width='200px' mr="45px" isReadOnly/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='10px'>
                                        <Center>
                                            <FormLabel>Numero de Boleta: </FormLabel>
                                            <Input type="text" id="boleta" placeholder={usuario.NoBoleta} bg='white' color='black' width='250px' mr='80px' isReadOnly/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='30px'>
                                        <Center>
                                            <Input type='button' mt='3px' width='30%' id='Modificar' borderColor='teal' value='Modificar' border='none' cursor='pointer' fontFamily={"Ubuntu"} bg='#3c3c3c'/>
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
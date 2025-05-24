import {Box, Center, FormControl, FormLabel, Heading, Input, Flex, Alert, Button } from '@chakra-ui/react';
import * as API from "./services/data";
import { useNavigate } from "react-router";
import { useState, useEffect } from 'react';


export function PantallaEditarPerfil() {
    const [usuario, setUsuario] = useState({Apatern:'', Amatern:'', Nombre:'', FechaNac:'', Correo:'', Password:'', ConfirmarPassword:'', NoBoleta:''});
    const navigate = useNavigate();
    const idUsuario = localStorage.getItem('idUsuario');
    // Censurar el correo hasta la @
    const censoredEmail = usuario.Correo.replace(/(.{2})(.*)(@.*)/, (_, p1, p2, p3) => `${p1}${'*'.repeat(p2.length)}${p3}`);

    // Recuperar los datos del usuario al cargar el componente
    useEffect(() => {
        API.RecuperarUsuario(idUsuario)
            .then(data => {
                setUsuario({
                    Apatern: data.apellidoPaterno,
                    Amatern: data.apellidoMaterno,
                    Nombre: data.nombres,
                    FechaNac: data.fechaNacimiento,
                    Correo: data.correoInstitucional,
                    NoBoleta: data.numBoleta
                });
            })}, [idUsuario]);



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
                                            <FormLabel>Correo: {censoredEmail}</FormLabel>
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
                                            <Input type="text" id="Date" bg='white' color='black' width='250px' mr="95px" placeholder={usuario.FechaNac} isReadOnly/>
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
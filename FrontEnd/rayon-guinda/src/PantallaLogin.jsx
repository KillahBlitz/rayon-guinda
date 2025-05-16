import redbuddy from "./media/buddyred.png";
import {Box, Center, FormControl, FormLabel, Heading, Input, Image, Link, Flex } from '@chakra-ui/react';
import { useNavigate } from "react-router";


export function PantallaLogin(){
    const navigate = useNavigate();
    
    function registrar(){
        navigate("./PantallaRegistro");
    }


    return(
    <>
        <Box bg="#4A0000" minHeight="100vh" width="100vw" overflow="hidden" m={0} p={0} fontFamily={"Open Sans"}>
            <Box mt='30px'>
                <Center>
                    <Image mt='3px' src={redbuddy} width='250px' height='250px'/>
                </Center>
                <Center>
                    <Box m='2%' width='45%' id='caja'>
                        <Center>
                            <Box borderRadius='md' width='80%' id='caja' bg='#ffffff3e' color='white'>
                                <Box textAlign='center'>
                                    <Heading>Inicia Sesión CINECLIC</Heading>
                                </Box>
                                <Box padding='20px'>
                                    <form id='login-form'>
                                        <FormControl mt='3px'>
                                            <FormLabel>Correo:</FormLabel>
                                            <Input type="text" id="Correo" placeholder="Escribe tu correo aquí" bg='white' color='black'/>
                                        </FormControl>
                                        <FormControl mt='3px'>
                                            <FormLabel>Contraseña:</FormLabel>
                                            <Input type="password" id="password" placeholder="Escribe tu contraseña aquí" bg='white' color='black'/>
                                        </FormControl>
                                        <br />
                                        <FormControl mt='3px'>
                                            <Center>
                                                <Input type='submit' mt='3px' mr='200px' width='30%' id='enviar' borderColor='teal' value='Registrarse' border='none' fontFamily={"Ubuntu"} cursor='pointer' bg='#7c0015' onClick={() => registrar()}/>
                                                <Input type='submit' mt='3px' width='30%' id='enviar' borderColor='teal' value='Acceder' border='none' fontFamily={"Ubuntu"} cursor='pointer' bg='#7c0015'/>
                                            </Center>
                                        </FormControl>
                                    </form>
                                </Box>
                            </Box>
                        </Center>
                        <Center>
                          <Link href="/PantallaRecuperarC" color="white" fontWeight="medium" fontFamily={"Ubuntu"}>Recuperar Contraseña</Link>
                        </Center>
                    </Box>
                </Center>
            </Box>
        </Box>
    </>
    )}
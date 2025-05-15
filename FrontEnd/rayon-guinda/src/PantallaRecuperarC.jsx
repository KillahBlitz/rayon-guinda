import {Box, Center, FormControl, FormLabel, Heading, Input, Image } from '@chakra-ui/react';
import { useNavigate } from "react-router";
import redbuddy from "./media/buddyred.png";

export function PantallaRecuperarC(){

    const navigate = useNavigate();
    function cancelar(){
        navigate("/");
    }

    return(
    <>
        <Box bg="#4A0000" minHeight="100vh" width="100vw" overflow="hidden" m={0} p={0} fontFamily={"Open Sans"}>
            <Box mt='30px'>
                <Center>
                    <Image mt='3px' src={redbuddy} width='250px' height='250px'/>
                </Center>
                <Center>
                        <Box borderRadius='md' m='2%' width='35%' id='caja' bg='#ffffff3e' color='white'>
                            <Box textAlign='center'>
                                <Heading>Recupera tu Contraseña</Heading>
                            </Box>
                            <Box padding='20px'>
                                <form id='register-form'>
                                    <FormControl mt='3px'>
                                        <FormLabel>Correo:</FormLabel>
                                        <Input type="text" id="Correo" placeholder="Escribe tu correo aquí" bg='white' color='black'/>
                                    </FormControl>
                                    <FormControl mt='3px'>
                                        <FormLabel>Selecciona tu fecha de nacimiento:</FormLabel>
                                        <Input type="date" id="date" bg='white' color='black' width='220px'/>
                                    </FormControl>
                                    <br />
                                    <FormControl mt='3px'>
                                        <Center>
                                            <Input type='submit' mt='3px' width='30%' id='cancelar' borderColor='teal' value='Cancelar' border='none' cursor='pointer' fontFamily={"Ubuntu"} bg='#7c0015' onClick={() => cancelar()}/>
                                            <Input type='submit' ml='200px' mt='3px' width='30%' id='registro' borderColor='teal' value='Recuperar' border='none' fontFamily={"Ubuntu"} cursor='pointer' bg='#7c0015'/>
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
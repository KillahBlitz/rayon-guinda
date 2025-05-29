import {Box, Center, FormControl, FormLabel, Heading, Input, Image, Button, HStack, Link, VStack, Flex } from '@chakra-ui/react';
import {  useState } from 'react';
import { useNavigate } from "react-router";
import redbuddy from "./media/buddyred.png";
import { SubPantallaGrupos } from './SubPantallaGrupos';

export function PantallaPrincipal(){
    const navigate = useNavigate();
    const idUsuario = localStorage.getItem('idUsuario');
    const [grupos, setGrupos] = useState([]);

    function cerrarSesion(){
        sessionStorage.removeItem("usuario");
        sessionStorage.removeItem("idUsuario");
        navigate("/");
    }

    function irAPerfil(){
        navigate(`/PantallaEditarPerfil?id=${idUsuario}`);
    }

    function AbrirGrupos(){
        setGrupos(<SubPantallaGrupos/>);
    }


    return(
        <>
        <Box bg="#ffffff" minHeight="100vh" height="20vw" width="100vw" overflow="hidden" m={0} p={0} fontFamily={"Open Sans"}>
            <Box bg="#4A0000" height="100px" width="100%" position='relative'>
                <br />
                <HStack as='nav' spacing='10px' ml="3px">
                    <VStack>
                        <Image src={redbuddy} width='100px' height='100px' cursor='pointer' ml='15px' onClick={() => irAPerfil()}/>
                        <Box ml='15px' px="20px" py="10px" color= "white">Perfil</Box>
                    </VStack>
                </HStack>
            </Box>
            <Flex height="100vh">
                <Box bg="#4A0000" height="100%" width="150px" id="sidebar">
                    <Box>
                        <Center>
                            <VStack spacing={4} align='stretch' mt='20%'>
                                <Box mt='150%'>
                                    <Button height="70px" width="100px" onClick={() => AbrirGrupos()}>Grupos</Button>
                                    <br/>
                                    <br/>
                                    <Button height="70px" width="100px">Foros</Button>
                                </Box>
                                <Box mt='150px'>
                                    <Button height="30px" width="100px">Chats</Button>
                                    <br/>
                                    <br/>
                                    <Button height="30px" width="100px" onClick={() => cerrarSesion()}>Cerrar Sesion</Button>
                                </Box>
                            </VStack>
                        </Center>
                    </Box>
                </Box>
                <Box height="100%" padding="20px" width="100%">
                    {grupos}
                </Box>
            </Flex>
        </Box>
        </>
    )
}
import {Box, Center, FormControl, FormLabel, Heading, Input, Flex, Alert, Button, useToast } from '@chakra-ui/react';
import * as API from "./services/data";
import { useNavigate } from "react-router";
import { useState, useEffect, useRef } from 'react';


export function PantallaEditarPerfil() {
    const [usuario, setUsuario] = useState({Apatern:'', Amatern:'', Nombre:'', FechaNac:'', Correo:'', Password:'', NoBoleta:''});
    const navigate = useNavigate();
    const idUsuario = localStorage.getItem('idUsuario');
    // Censurar el correo antes de la @ y después de la @ ver el dominio del correo
    const censoredEmail = usuario.Correo.replace(/^[^@]+/, match => '*'.repeat(match.length));

    //variables vizuales para el toast y el input de la contraseña
    const toast = useToast();
    const inputRef = useRef(null);

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
                    NoBoleta: data.numBoleta,
                    Password: data.password
                });
            })}, [idUsuario]);


    //funcion que al dar click al boton modificar, aparezca un mensaje de alerta en medio de la pantalla que te pida la contraseña
    function ConfirmarIdentidad(){
        toast.closeAll(); // Cierra cualquier toast abierto antes de mostrar uno nuevo
        toast({ duration: null, isClosable: true, position: 'top',
            render: ({ onClose }) => (
                <Center>
                    <Box p="20" bg="#4A0000" color="white" fontSize="xl" borderRadius="lg" boxShadow="xl" mt="150px" textAlign="center" minW="400px" >
                    <Flex direction='column' alignItems='center'>
                        <Center>
                            <FormLabel fontSize="30px">Ingresa tu contraseña</FormLabel>
                        </Center>
                        <Center mt="20px">
                            <Input type="password" id="ConfirmPassword" ref={inputRef} placeholder="Contraseña" bg='white' color='black' width='300px' />
                        </Center>
                        <Center>
                            <Button mt="30px" mr="50px" colorScheme="teal" width="100px" bg= "#3c3c3c" _hover={{ bg: "#6d3535" }} onClick={onClose} >Cancelar</Button>
                            <Button mt="30px" ml="50px" colorScheme="teal" width="100px" bg= "#3c3c3c"  _hover={{ bg: "#6d3535" }} onClick={validarContrasena} >Enviar</Button>
                        </Center>
                    </Flex>
                    </Box>
                </Center>
            )
        });
    }
    
    //Funcion que valida la contraseña
    function validarContrasena(){
        toast.closeAll();
        const inputRefValue = inputRef.current.value; // Obtener el valor del input de contraseña
        if(inputRefValue === usuario.Password){
            navigate(`/PantallaModificadoraDatos?id=${idUsuario}`);
        }else{
            return(
                toast({ duration: 3000, isClosable: true, position: 'top',
                    render: () => (
                        <Alert status='error' variant='solid' width='300px' borderRadius='md'>
                            <Box color='white'>
                                Contraseña incorrecta
                            </Box>
                        </Alert>
                    )
                }
            ))
        }
    }


    function volver(){
        toast.closeAll();
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
                                            <Input type="text" id="Apatern" value={usuario.Apatern} bg='white' color='black' width='250px' mr='70px' isReadOnly/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='10px'>
                                        <Center>
                                            <FormLabel>Apellido Materno: </FormLabel>
                                            <Input type="text" id="Amatern" value={usuario.Amatern} bg='white' color='black' width='250px' mr='75px' isReadOnly/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='10px'>
                                        <Center>
                                            <FormLabel>Nombre(s): </FormLabel>
                                            <Input type="text" id="Nombre" value={usuario.Nombre} bg='white' color='black' width='250px' mr='30px' isReadOnly/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='10px'>
                                        <Center>
                                            <FormLabel>Fecha de nacimiento: </FormLabel>
                                            <Input type="date" id="Date" bg='white' color='black' width='250px' mr="95px" value={usuario.FechaNac} isReadOnly/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='10px'>
                                        <Center>
                                            <FormLabel>Numero de Boleta: </FormLabel>
                                            <Input type="text" id="boleta" value={usuario.NoBoleta} bg='white' color='black' width='250px' mr='80px' isReadOnly/>
                                        </Center>
                                    </FormControl>
                                    <FormControl mt='30px'>
                                        <Center>
                                            <Input type='button' mt='3px' width='30%' id='Modificar' borderColor='teal' value='Modificar' border='none' cursor='pointer' fontFamily={"Ubuntu"} bg='#3c3c3c' onClick={() => {ConfirmarIdentidad()}}/>
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
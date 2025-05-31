import {Box, Center, Input, Button, Flex, Alert, FormLabel, HStack, useToast} from '@chakra-ui/react';
import * as API from "./services/data";
import { useEffect, useState, useRef } from 'react';


export function SubPantallaGrupos() {
    const [grupos, setGrupos] = useState([]);
    const idUsuario = localStorage.getItem('idUsuario');
    const inputRefName = useRef(null);
    
    //variables vizuales para el toast
    const toast = useToast();
    
    useEffect(() => {
        (async () => {
            await fetchGrupos();
        })();
    });


    async function fetchGrupos() {
        API.RecuperarGruposUsuario(idUsuario)
            .then(data => {
                setGrupos(data);
            })
    }

    //funcion de crear grupo
    async function CreaciondelGrupo(nuevoCodigo) {
        toast.closeAll(); // Cierra cualquier toast abierto antes de mostrar uno nuevo
        if (inputRefName.current.value === ""){
            toast({ title: "Se debe ingresar un nombre para el grupo", status: "error", duration: 3000, isClosable: true, position: "top"});
        }
        else {
            const nombreGrupo = inputRefName.current.value;
            const codigoGrupo = nuevoCodigo;
            const usuario = idUsuario; // Asumiendo que el nombre del usuario está guardado en localStorage

            console.log(usuario, nombreGrupo, codigoGrupo);

            const response = await API.CrearGrupo(usuario, nombreGrupo, codigoGrupo)

            if (response === true || response === "true") {
                toast({ title: "Grupo Creado Correctamente", status: "success", duration: 3000, isClosable: true, position: "top"});
                fetchGrupos(); // Actualiza la lista de grupos
            }else{
                toast({ title: "Ocurrio un Error Inesperado", status: "error", duration: 3000, isClosable: true, position: "top"});
            }
        }
    }

    
    // funcion se ejecuta para crear grupos o unirse a grupos
    async function CrearGrupo() {
        toast.closeAll(); // Cierra cualquier toast abierto antes de mostrar uno nuevo
        const nuevoCodigo = await API.RecuperarCodigoGrupo(); // Espera a que llegue el código

        toast({ duration: null, isClosable: true, position: 'top',
            render: ({ onClose }) => (
            <Center>
                <Box p="20" bg="#4A0000" color="white" fontSize="xl" borderRadius="lg" boxShadow="xl" mt="250px" textAlign="center" minW="400px" >
                <Flex direction='column' alignItems='center'>
                    <Center>
                        <FormLabel fontSize="30px">Crear un Grupo</FormLabel>
                    </Center>
                    <Center mt="20px">
                        <Input type="text" id="NombreGrupo" placeholder="Nombre del Grupo" bg='white' color='black' width='300px' ref={inputRefName}/>
                    </Center>
                    <Center>
                        <FormLabel fontSize="14px" mt="20px">La clave de tu grupo es {nuevoCodigo}, debes anotarlo porque sera la unica vez que podras verlo en la plataforma</FormLabel>
                    </Center>
                    <Center>
                        <Button mt="30px" ml="50px" mr="50px" colorScheme="teal" width="100px" bg= "#3c3c3c" _hover={{ bg: "#ffffff", color:"#000000" }} onClick={onClose} >Cancelar</Button>
                        <Button mt="30px" ml="50px" mr="50px" colorScheme="teal" width="100px" bg= "#3c3c3c" _hover={{ bg: "#ffffff", color:"#000000" }} onClick={() => {CreaciondelGrupo(nuevoCodigo)}} >Crear</Button>
                    </Center>
                </Flex>
                </Box>
            </Center>
            )
        });
    }
    
    function handleCrearoUnirseGrupo() {
        toast.closeAll(); // Cierra cualquier toast abierto antes de mostrar uno nuevo
        toast({ duration: null, isClosable: true, position: 'top',
            render: ({ onClose }) => (
            <Center>
                <Box p="20" bg="#4A0000" color="white" fontSize="xl" borderRadius="lg" boxShadow="xl" mt="250px" textAlign="center" minW="400px" >
                <Flex direction='column' alignItems='center'>
                    <Center>
                        <FormLabel fontSize="30px">Selecciona una opcion</FormLabel>
                    </Center>
                    <Center mt="20px">
                        <Button fontSize="30px" ml="50px" mr="50px" colorScheme="teal" width="200px" height="100px" bg= "#3c3c3c" _hover={{ bg: "#ffffff", color:"#000000" }} onClick={CrearGrupo} >Crear Grupo</Button>
                        <Button fontSize="30px" mr="50px" colorScheme="teal" width="200px" height="100px" bg= "#3c3c3c" _hover={{ bg: "#ffffff", color:"#000000" }} onClick={onClose} >Añadir Grupo</Button>
                    </Center>
                    <Center>
                        <Button mt="30px" ml="50px" mr="50px" colorScheme="teal" width="100px" bg= "#3c3c3c" _hover={{ bg: "#ffffff", color:"#000000" }} onClick={onClose} >Cancelar</Button>
                    </Center>
                </Flex>
                </Box>
            </Center>
            )
        });
    }

    
    return (
    <>
        <Center>
            <Box mt='30px'>
                <Box textAlign='center' fontSize='30px'>
                    <h1>Grupos a los que Perteneces</h1>
                </Box>
            </Box>
        </Center>
        <HStack spacing='20px' padding='20px' alignItems='center'>
            {// Mapeo de los grupos para mostrarlos en la pantalla en forma de botones solo el nombre
            grupos.map((grupo) => (
                <Box key={grupo} padding='10px'>
                    <Button width='200px' height='100px' bgColor='#4A0000' _hover={{ bg: "#3c3c3c" }} color='white' variant='solid' fontSize='18px' whiteSpace="normal" textAlign="center" display="flex" alignItems="center" justifyContent="center" px={2} py={2}>
                        {grupo}
                    </Button>
                </Box>
            ))}
            <Box padding='10px'>
                <Button width='100px' height='100px' bgColor='#4A0000'  _hover={{ bg: "#3c3c3c" }} color='white' variant='solid' fontSize='40px' onClick={handleCrearoUnirseGrupo}>+</Button>
            </Box>
        </HStack>
    </>
    )
}
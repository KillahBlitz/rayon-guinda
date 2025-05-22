import {Box, Center, FormControl, FormLabel, Heading, Input} from '@chakra-ui/react';

export function PantallaCambiarC(){

    return(
    <>
        <Box bg="#4A0000" minHeight="100vh" width="100vw" overflow="hidden" m={0} p={0} fontFamily={"Open Sans"}>
            <Box mt='150px'>
                <Center>
                        <Box borderRadius='md' m='2%' width='35%' id='caja' bg='#ffffff3e' color='white'>
                            <Box textAlign='center'>
                                <Heading>Recupera tu Contraseña</Heading>
                            </Box>
                            <Box padding='20px'>
                                <form id='register-form'>
                                    <FormControl mt='3px'>
                                        <FormLabel>Nueva Contraseña:</FormLabel>
                                        <Input type="password" id="newpassword" placeholder="Escribe tu nueva contraseña" bg='white' color='black'/>
                                    </FormControl>
                                    <FormControl mt='3px'>
                                        <FormLabel>Confirma Nueva Contraseña:</FormLabel>
                                        <Input type="password" id="confirmnewpassword" placeholder="Confirma tu nueva contraseña" bg='white' color='black'/>
                                    </FormControl>
                                    <br />
                                    <FormControl mt='3px'>
                                        <Center>
                                            <Input type='submit'width='40%' id='CambiarC' borderColor='teal' value='Recuperar Contraseña' border='none' fontFamily={"Ubuntu"} cursor='pointer' bg='#7c0015'/>
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
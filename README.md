Está API, cuenta con dos end points

1. api/Auth/Login: Este end point, verifica en base a un nombre de usuario y una contraseña que exista un usuario con esas credenciales, 
  si existe dicho usuario retorna un Jwt que luego será usado para consumir los otros servicios que tiene la API, de lo contrario retornará un error.
 
2. api/Domino: Este end point, recibe una lista de array de ints, que son la presentación de las fichas de dominos, hace una serie de validaciones y retorna error
  en caso de que no cumplan, de lo contario retona todas las combinaciones que se pueden generar.
  
Esta API, cuenta con un único usuario de prueba, el cual es username = developer, password = inalambria2023*

Desarrollado por Andrés Felipe Puello Osorio - Fullstack Developer

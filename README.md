# Clima en una galaxia muy muy lejana........ 


### Ejercicio:
En una galaxia lejana, existen tres civilizaciones. Vulcanos, Ferengis y Betasoides.   
Cada civilización vive en paz en su respectivo planeta. Dominan la predicción del clima mediante un complejo sistema informático.   
A continuación el diagrama del sistema solar.

### Premisas:
**_El planeta Ferengi_** se desplaza con una velocidad angular de 1 grados/día en sentido horario. Su distancia con respecto al sol es de 500Km.  
**_El planeta Betasoide_** se desplaza con una velocidad angular de 3 grados/día en sentido horario. Su distancia con respecto al sol es de 2000Km.  
**_El planeta Vulcano_** se desplaza con una velocidad angular de 5 grados/día en sentido anti­horario, su distancia con respecto al sol es de 1000Km.  
Todas las órbitas son circulares.  
Cuando los tres planetas están alineados entre sí y a su vez alineados con respecto al sol, el sistema solar experimenta un período de sequía.   
Cuando los tres planetas no están alineados, forman entre sí un triángulo. Es sabido que en el momento en el que el sol se encuentra dentro del triángulo, el sistema solar experimenta un período de lluvia, teniendo éste, un pico de intensidad cuando el perímetro del triángulo está en su máximo.  
Las condiciones óptimas de presión y temperatura se dan cuando los tres planetas están alineados entre sí pero no están alineados con el sol.  

Realizar un programa informático para poder predecir en los próximos 10 años:  

¿Cuántos períodos de sequía habrá?  
¿Cuántos períodos de lluvia habrá y qué día será el pico máximo de lluvia?  
¿Cuántos períodos de condiciones óptimas de presión y temperatura habrá?  

### Bonus 
Para poder utilizar el sistema como un servicio a las otras civilizaciones, 
los Vulcanos requieren tener una base de datos con las condiciones meteorológicas de 
todos los días y brindar una API REST de consulta sobre las condiciones de un día en particular.  

1) Generar un modelo de datos con las condiciones de todos los días hasta 10 años en adelante utilizando un job para calcularlas.  
2) Generar una API REST la cual devuelve en formato JSON la condición climática del día consultado.  
3) Hostear el modelo de datos y la API REST en un cloud computing libre (como APP Engine o Cloudfoudry) y 
enviar la URL para consulta:  
Ej: GET → http://....../clima?dia=566 → Respuesta: {“dia”:566, “clima”:”lluvia”}  



## RESOLUCION  

**Toda el problema con su explicación lógica se encuentra en el archivo PDF.**

### Anotaciones  
- Ferengi: 360 dias en dar la vuelta
- Vulcano: 72 dias en dar la vuelta
- Betasoide: 120 dias en dar la vuelta
- Para calcular los 10 años se utilizará el planeta Ferengi, así las otras civilizaciones tienen ese periodo para calcular
- Cuando los planetas no están alineados siempre forman un triángulo.
- Cuando el sol no está dentro del triángulo el tiempo se considera "No Definido", ya que el problema no menciona nada al respecto de esto
- Toda la carga de la base de datos se hace con el JOB, que estará guardando la información para luego buscarla por medio de la API
- Los calculos de las API se hacen al periodo de 10 años, con la excepción que busca un día particular.


### API REST
- Incio de la aplicación: https://meliplanetas.azurewebsites.net
- Total de días de sequía: https://meliplanetas.azurewebsites.net/Clima/Sequia
- Total de días de lluvia con los días con Picos Máximos: https://meliplanetas.azurewebsites.net/Clima/Lluvia
- Total de días de óptimos: https://meliplanetas.azurewebsites.net/Clima/Optimos

**Bonus**
- JOB se encuentra dentro de la carpeta "Models"
- Devuelve día seleccionado: https://meliplanetas.azurewebsites.net/Clima?dia=560
- Esta hosteado en Azure que me otorga crédito libre por el período de 1 años. (No encontre un host gratuito para .NET)


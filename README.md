# TFM_CarratalaRizzo-Valderico
 

En este repositorio podemos encontrar dos carpetas, cuyo contenido es el siguiente:
- **config**: en esta carpeta se encuentran todos los ficheros de configuración YAML utilizados para el desarrollo de este proyecto.
- **Examples**: en esta carpeta se encuentran los diferentes códigos y escenas de Unity utilizadas para cada uno de los entornos, así como los elementos necesarios para su funcionamiento.
	- Final Environments: aquí se encuentran cada uno de los entornos finales descritos en el apartado de experimentación.
	- Previous Environments: aquí se encuentran cada uno de los entornos de prueba realizados previamente a los entornos finales.
- **Enviroments**: en esta carpeta se encuentran los diferentes ejecutables de los entornos, dentro de cada uno encontramos tres opciones:
        - Camera\_Agent: Entorno con el modelo de RL implementado y la cámara general habilitada.
        - Camera\_Normal: Entorno con el modelo de RL implementado y la cámara del agente habilitada.
        - Heuristic: Entorno en modo de control manual (sin el modelo de RL implementado) y la cámara del agente habilitada.
    
Si se desean probar los escenarios, únicamente es necesario acceder a la carpeta de Enviroments y ejecutar el archivo 'UnityEnvironment.exe' del entorno deseado.

Si por otro lado se quisieran modificar o ampliar los escenarios, es preciso realizar la configuración previa en Unity y ML-Agents mencionada en la documentación de ML-Agents  (la cual se comenta en el TFM dentro del Apéndice A), y posteriormente copiar el contenido de la carpeta 'Examples' donde se encuentran el resto de ejemplos del repositorio de la librería ML-Agents. Una vez hecho esto, únicamente hay que abrir el proyecto en Unity, seleccionar el escenario que queramos probar, y darle al play para ver a los agentes funcionar en modo de inferencia (ya que los agentes ya llevan acoplados el cerebro del mejor entrenamiento realizado para cada uno de los entornos). 

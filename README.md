# Aprendizaje por refuerzo en sistemas mono y multiagente: 
## Análisis e implementación de diferentes sistemas de Deep RL sobre el framework de Unity

## Introducción

El objetivo de este Trabajo Fin de Máster es implementar una serie de sistemas que me permita analizar la viabilidad del desarrollo de agentes inteligentes de forma fácil, rápida y a bajo coste.

Por lo tanto, se implementarán una serie de sistemas en los cuales, uno o varios agentes aprendan a realizar una tarea simple mediante la interacción directa con el entorno gracias al aprendizaje por refuerzo.

Para el desarrollo de este proyecto utilizaremos el entorno de simulación de Unity, y su librería de aprendizaje por refuerzo ’ML-Agents’, gracias a los cuales seremos capaces de diseñar y entrenar entornos tanto monoagentes como multiagentes, sin necesidad de una enorme capacidad computacional. 


## Contenido del repositorio

En este repositorio podemos encontrar 4 carpetas, cuyo contenido es el siguiente:
- **Enviroments**: en esta carpeta se encuentran los diferentes ejecutables de los entornos, dentro de cada uno encontramos tres opciones:
        - Camera\_Agent: Entorno con el modelo de RL implementado y la cámara general habilitada.
        - Camera\_Normal: Entorno con el modelo de RL implementado y la cámara del agente habilitada.
        - Heuristic: Entorno en modo de control manual (sin el modelo de RL implementado) y la cámara del agente habilitada.
- **Examples**: en esta carpeta se encuentran los diferentes códigos y escenas de Unity utilizadas para cada uno de los entornos, así como los elementos necesarios para su funcionamiento.
	- Final Environments: aquí se encuentran cada uno de los entornos finales descritos en el apartado de experimentación.
	- Previous Environments: aquí se encuentran cada uno de los entornos de prueba realizados previamente a los entornos finales. 
- **config**: en esta carpeta se encuentran todos los ficheros de configuración YAML utilizados para el desarrollo de este proyecto.
- **TFM_Examples_rar**: En esta carpeta se encuentran los rar con los diferentes códigos y escenas de Unity utilizadas para cada uno de los entornos, así como los elementos necesarios para su funcionamiento.
	
Si se desean probar los escenarios, únicamente es necesario acceder a la carpeta de Enviroments y ejecutar el archivo 'UnityEnvironment.exe' del entorno deseado.

Si por otro lado se quisieran modificar o ampliar los escenarios, es preciso realizar la configuración previa en Unity y ML-Agents mencionada en la documentación de ML-Agents  (la cual se comenta en el TFM dentro del Apéndice A), y posteriormente copiar el contenido de la carpeta 'Examples' donde se encuentran el resto de ejemplos del repositorio de la librería ML-Agents. Una vez hecho esto, únicamente hay que abrir el proyecto en Unity, seleccionar el escenario que queramos probar, y darle al play para ver a los agentes funcionar en modo de inferencia (ya que los agentes ya llevan acoplados el cerebro del mejor entrenamiento realizado para cada uno de los entornos). 


---

## Reinforcement learning in single and multi-agent systems: 
## Analysis and implementation of different Deep RL systems on the Unity framework.

## Introduction

The objective of this Master Thesis is to implement a series of systems that allow me to analyze the feasibility of developing intelligent agents easily, quickly and at low cost.

Therefore, a series of systems will be implemented in which one or several agents learn to perform a simple task through direct interaction with the environment thanks to reinforcement learning.

For the development of this project we will use the Unity simulation environment, and its reinforcement learning library 'ML-Agents', thanks to which we will be able to design and train both single-agent and multi-agent environments, without the need of a huge computational capacity. 


## Repository contents

In this repository we can find 4 folders, whose content is the following:
- **Enviroments**: in this folder we can find the different executables of the environments, inside each one we can find three options:
        - Camera_Agent: Environment with the RL model implemented and the general camera enabled.
        - Camera_Normal: Environment with the RL model implemented and the agent's camera enabled.
        - Heuristic: Environment in manual control mode (without the RL model implemented) and the agent's camera enabled.
- **Examples**: in this folder you can find the different Unity codes and scenes used for each of the environments, as well as the necessary elements for its operation.
	- Final Environments: here you will find each of the final environments described in the experimentation section.
	- Previous Environments: here you will find each one of the test environments made before the final environments. 
- **config**: this folder contains all the YAML configuration files used for the development of this project.
- **TFM_Examples_rar**: In this folder you will find the rar files with the different Unity codes and scenes used for each of the environments, as well as the necessary elements for their operation.
	
If you wish to test the scenarios, it is only necessary to access the Enviroments folder and execute the file 'UnityEnvironment.exe' of the desired environment.

If, on the other hand, you would like to modify or extend the scenarios, it is necessary to perform the previous configuration in Unity and ML-Agents mentioned in the ML-Agents documentation (which is discussed in the TFM in Appendix A), and then copy the contents of the 'Examples' folder where the rest of the examples from the ML-Agents library repository are located. Once this is done, we only have to open the project in Unity, select the scenario we want to test, and press play to see the agents working in inference mode (since the agents already have the brain of the best training performed for each of the environments). 

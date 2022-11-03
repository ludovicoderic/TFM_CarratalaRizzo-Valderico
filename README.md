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

# Reinforcement learning in single and multi-agent systems:
## Analysis and implementation of different Deep RL systems on the Unity framework

## Introduction

The objective of this Master's Thesis is to implement a series of systems that allow me to analyze the feasibility of developing intelligent agents in an easy, fast and low-cost way.

Therefore, a series of systems will be implemented in which one or several agents learn to perform a simple task through direct interaction with the environment thanks to reinforcement learning.

For the development of this project we will use the Unity simulation environment, and its reinforcement learning library 'ML-Agents', thanks to which we will be able to design and train both single-agent and multi-agent environments, without the need for enormous computational capacity. .


## Repository content

In this repository we can find 4 folders, whose content is as follows:
- **Enviroments**: in this folder are the different executables of the environments, within each one we find three options:
        - Camera\_Agent: Environment with the RL model implemented and the general camera enabled.
        - Camera\_Normal: Environment with the RL model implemented and the agent's camera enabled.
        - Heuristic: Environment in manual control mode (without the RL model implemented) and the agent's camera enabled.
- **Examples**: in this folder you will find the different Unity codes and scenes used for each of the environments, as well as the elements necessary for their operation.
- Final Environments: here are each of the final environments described in the experimentation section.
- Previous Environments: here are each of the test environments made prior to the final environments.
- **config**: in this folder are all the YAML configuration files used for the development of this project.
- **TFM_Examples_rar**: In this folder you will find the rar files with the different Unity codes and scenes used for each of the environments, as well as the elements necessary for their operation.

If you want to test the scenarios, you only need to access the Environments folder and run the 'UnityEnvironment.exe' file of the desired environment.

If, on the other hand, you want to modify or extend the scenarios, you must make the previous configuration in Unity and ML-Agents mentioned in the ML-Agents documentation (which is discussed in the TFM in Appendix A), and then copy the content of the 'Examples' folder where the rest of the examples of the ML-Agents library repository are located. Once this is done, all you have to do is open the project in Unity, select the scenario you want to test, and press play to see the agents work in inference mode (since the agents already have the best training brain attached to them). each environment).

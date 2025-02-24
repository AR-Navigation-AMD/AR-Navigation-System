Our AR navigation system combines several sophisticated technologies to deliver a seamless and efficient navigation experience. Initially, we explored Visual SLAM (Simultaneous Localization and Mapping), a technique that utilizes visual input from cameras to construct a map of the environment while concurrently tracking the device's location within that map. Despite its potential, Visual SLAM presented optimization challenges, particularly in dynamic or complex environments where its performance could degrade.

To address these limitations, we incorporated Unity, a versatile game development platform renowned for its capabilities in AR development. Unity enables the creation of immersive AR experiences and can integrate data from various sources to enhance accuracy. This platform allows for the precise rendering of AR elements, offering users an interactive navigation experience. Furthermore, satellite tracking, such as GPS, provides reliable geographic positioning data, particularly valuable in outdoor settings where Visual SLAM may falter.

We also implemented Vuforia, a software platform specializing in augmented reality (AR) technology, which facilitates the recognition of images and objects in the real world and overlays digital content onto them. Utilizing Vuforia's AR camera, we successfully overlaid digital information, such as a custom-developed digital cube, enhancing the project. Additionally, we developed code to track the device's position and input the coordinates of the source and destination. This functionality triggers AR pop-ups in the environment with messages like "You have reached your destination" or "Turn on your GPS," along with the generation of an AR cube at the destination point.

Real-time data synchronization is critical for maintaining accuracy and coherence within our AR system. To achieve this, we implemented Socket.IO, a JavaScript library that enables real-time, bidirectional communication between server and client applications. Socket.IO facilitates the instantaneous transmission of tracking data and updates, ensuring that all devices and users have access to the latest information. This real-time communication is essential for synchronizing movements and positional data across multiple devices, resulting in a consistent and responsive navigation experience.

By integrating these technologies—Vuforia for AR overlays, satellite tracking for global positioning, Unity for AR development, and Socket.IO for real-time data exchange—we have created a robust AR navigation system. This comprehensive approach allows the system to provide accurate, interactive, and adaptive navigation solutions for both indoor and outdoor environments.

CONTRIBUTORS : 
 • Shreya C Bharadwaj 
 • Prajwal Mundargi 
 • Nandan M Naik 
 • Maheshwari M 

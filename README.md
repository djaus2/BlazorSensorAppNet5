# BlazorIoTBridge

### Version: 2.00 (Beta)
**NB: _THERE HAVE BEEN SOME SIGNIFICANT UNDOCUMENTED CHANGES SUCH AS SETTINGS IN A DATABASE THAT IS QUERIED USING A GUID AS AN ID._ WATCH THIS SPACE**

## Background
This is a  .Net 5 version update of
[djaus2/BlazorSensorApp](https://github.com/djaus2/SensorBlazor). This forwarded Telemetry messages to an IoT Hub. The telemetry could be generated in the Blazor Client. Alternatively there were Arduino and .Net Core console app RPi apps that could forward simulated or real telemetry via Http Posts to the Blazor service for on-forwarding. This version continues with a port of the console app to .Net 5, still forwarding Telemetry to the service via Http Posts _(for on-forwarding to the hub)_. The app has two modes of operation; for this it runs in Http mode. The Http Post option for Arduino has been dropped _(to be added back later)_, but reimplemented using the USB serial connection to a desktop. With this the console app runs in the alternative mode where it communicates with the Arduino device serially to get telemetry and send commands. IoT Hub commands can be sent to the device whether he console app is running in Http Post mode, or in the Arduino serial mode.  

![Architecture](https://davidjones.sportronics.com.au/media/iotbridge.png)  
The architecture of this solution.

## Other
There is a PnP oriented Azure IoTBridge app: [Azure IoT Central Device Bridge](https://github.com/Azure/iotc-device-bridge).  This project is a simpler implementation without PnP capabilities. This project is simply focused upon sending and monitoring Telemetry as well as implementing commands.

## Other Links
- [Azure IoT device SDKs](https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-sdks)
- In another previous project, [Azure IoT Hub Toolbox](https://github.com/djaus2/Azure.IoTHub.Toolbox) the Azure IoT Hub SDK Quickstarts sample apps were integrated into a single UWP app (with a UI). This new project implements similar functionality. 
- Much work has also been done to orchestrate Azure IoT Hub and related entities as a set of PowerShell scripts. That project is [Azure IoT Hub PowerShell Scripts](https://github.com/djaus2/az-iothub-ps) This is a menu driven set of scripts. It includes sample apps to deploy, Az Sphere etc.

## Functionality

-   Blazor Server for forwarding telemetry to an Azure IoT Hub
    -   Connection strings required
    -   Currently in server appsettings.json
    -   _(Client has page for setting connection strings but currently not used.)_
-   Wasm Client app for forwarding simulated telemetry via the server.
-   Can similarly on-forward real or simulated telemetry from RPi, Arduino etc
-   -   .Net console app for desktop and say, RPi, that forwards telemetry via Http Post
        to the Blazor service … simulated data at this stage.
    -   Arduino app that forwards via a serial port to the Blazor service …
        simulated data at this stage
        -   The original BlazorSensorApp solution had an Arduino Http Post
            version of the app. This will be re-added later.
-   Can monitor IoT messages sent from the service (view on Client)
    -   Directly via a transmission log kept on the service.
    -   Via a D2C monitoring of messages to the IoT Hub . (Integration of the
        Quickstarts **ReadD2cMessages** sample app).
        -   **Nb:** Actually runs as a separate app that forwards to the service
            via Http
        -   The D2C sample app remains as a .NetStandard app (couldn’t be ported
            to .Net5).
        -   It forwards message information over Http to the service
-   Can send commands to the device *(whether simulated or not)*
    -   Direct from the client.
    -   Via the IoT Hub: Direct (with Blazor service) integration of the
        Quickstarts **InvokeDeviceMethodApp** sample app.
        -   Service integrates invocation functionality from the Quickstarts
            **SimulatedDeviceWithCommand** sample app for monitoring commands
            submitted via the IoT Hub.
    -   Service maintains a ConcurrentQueue of commands received directly or
        from the hub that is polled by the device.
    -   (Simulated) device apps forward a list of commands at start that the
        Client uses to generate a menu of commands.
        
 ## 2Dos
 - Recreate Http Post Arduino app
 - Add back in real sensor telemetry to devices.
 - Allow for multiple devices to simultaneously use same Blazor service.
 - Setting or registering device specific connection information via the client.

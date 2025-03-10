# window_Weighbridge-
A Windows-based Weighbridge System built using C#, .NET, and Serial Communication to integrate with a weighing machine and capture weight data in real-time.

🔹 Features
✅ Serial Port Communication – Automatically detects and reads weight data from a connected weighing machine.
✅ Data Cleaning & Processing – Filters the received data to extract accurate weight values.
✅ Error Logging – Logs any errors encountered while reading data to a file for debugging.
✅ User-Friendly UI – Simple Windows Forms interface for displaying weight readings.

🛠️ Technologies Used
🔹 C# (.NET Framework) - Core language for application development.
🔹 Windows Forms (WinForms) - GUI for user interaction.
🔹 SerialPort Communication - To read weight data from the weighing machine.
🔹 Oracle Database (Optional) - For storing weight records (future enhancement).

🚀 How to Use?
1️⃣ Connect the weighing machine to the system via a serial port (RS232/USB).
2️⃣ Run the application and click the "Get Weight" button.
3️⃣ The system will automatically detect the port and fetch weight readings.
4️⃣ Logs errors (if any) to error_log.txt for debugging.

📌 Future Enhancements
🔹 Database Integration – Store weight records in Oracle SQL Server.
🔹 Multiple Port Support – Allow selection of different COM ports.
🔹 Real-time Data Logging – Maintain a history of weight readings.

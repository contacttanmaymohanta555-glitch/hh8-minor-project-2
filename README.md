# 🛡️ Endpoint Security Monitor – Device Health Tracker

A lightweight **Endpoint Security Monitoring Agent** built using **C# and .NET 8.0**, designed to monitor critical security parameters of Windows systems such as **Antivirus status** and **Disk Encryption (BitLocker)**. The agent runs in the background and periodically reports device health to a centralized server via REST API.

---

## 📌 Project Overview
This project simulates a basic **endpoint compliance monitoring system**, similar to what is used in enterprise EDR (Endpoint Detection and Response) solutions. 

## ✨ Features
- ✅ Monitors **Antivirus status** (Enabled / Disabled)
- 🔐 Checks **Disk Encryption (BitLocker)** status
- 🔄 Periodically pings a server with "Encrypted: Yes/No" status
- 🪶 Lightweight background agent
- 🖥️ Built for Windows OS using **.NET**

---

## 🧱 Project Architecture
The system consists of two main components communicating over HTTPS:

1. **AgentApp (The Tracker)**: A C# console application that checks local system security settings.
2. **MonitorServer (The Receiver)**: An ASP.NET Core Web API that receives and logs health reports.



---

## 🛠️ Technologies Used
- **C# / .NET 8.0**: Core programming and framework.
- **ASP.NET Core**: Server-side REST API.
- **WMI / PowerShell**: Antivirus and BitLocker detection.

---

## ⚙️ How to Run
1. Open the solution in **Visual Studio 2022**.
2. Set **Multiple Startup Projects** to run both `MonitorServer` and `AgentApp`.
3. Trust the SSL certificates when prompted.
4. View real-time security logs in the Server console.

---

## 📸 Screenshots
### 🔹 Server Receiving Security Reports
![Server Logs](screenshots/se<img width="1920" height="1080" alt="server-logs" src="https://github.com/user-attachments/assets/bbb03cdf-b380-4a90-8366-200408444ee7" />
rver-logs.png)

### 🔹 Agent Running Health Checks
![Agent Console](screen<img width="1920" height="1080" alt="Agent-console" src="https://github.com/user-attachments/assets/ab3665b1-fe52-469d-93d4-438b1cde5b01" />
shots/agent-console.png)

## 👨‍💻 Author
Tanmay Mohanta

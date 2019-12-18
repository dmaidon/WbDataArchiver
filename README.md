# WbDataArchiver
Desktop utility to fetch and archive the Meteobridge/Weatherbridge data.

Folder layout:

 C:\WbDataArchiver
   - Archives
     - Daily
     - Days
     - Years
   - Settings
      

Information required:
  1. Weatherbridge login name
  2. Weatherbridge login password
  3. IP address of the Weatherbridge on your local network.
  4. Fetch frequency of the current data archive in seconds. Ex: 90
  
Create a comma delimited file named "settings.csv" and place in the "Settings" folder.

Example:

#Name,Password,IP Address,CurUp Time (Sec)

meteobridge,myPassword,192.168.0.16,90

A Year folder is created for each year. (Example: 2019)  All archive files are placed within this Year folder.

"CurUp" = Current data update timer
Run WbDataArchiver and the current data will be saved to the Year folder in a file named: "MMddyyyy.csv". Ex: 12042019.csv
A new file will be created each day and the information is appended to that file.
On the upper status bar there is a countdown timer until the next current data update.  

"MidUp" = Midnight update timer
Counts down the minutes and seconds to the midnight rollover event which fetches the data for yesterday and save it to the Year folder in a file named: "MMMyyyy.csv". Ex: Dec2019.csv
A separate line is appended to this file for each day.

"YrUp" = Monthly update timer
Counts down the minutes and seconds to the midnight rollover event which fetches the data for yesterday and save it to the Year folder in a file named: "yyyy.csv". Ex: 2019.csv
A separate line of data is appended to this file for each month.

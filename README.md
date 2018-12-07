# like-ipconfig
Intended to be like _ipconfig_ on windows

written in C# - this program  illustrates the usage of System.Net.NetworkInformation

Outputs network information to the console in a very similar manner to the ipconfig.exe on windows. 

Sample Output
-------------
```
Active Network Interfaces
=========================

Ethernet adapter Ethernet 3
---------------------------
Description . . . . . . . . . . . . . . . : TAP-Windows Adapter V9
Physical Address  . . . . . . . . . . . . : 00FF11002233
Operational status  . . . . . . . . . . . : Up
DNS Services  . . . . . . . . . . . . . . : dynamic
DNS Servers . . . . . . . . . . . . . . . : 209.222.18.222
                                          : 209.222.18.218
IPv4 DHCP Enabled . . . . . . . . . . . . : True
IPv4 MTU  . . . . . . . . . . . . . . . . : 1500
IPv6 MTU  . . . . . . . . . . . . . . . . : 1500
IPv6 Interface Index  . . . . . . . . . . : 18
Speed . . . . . . . . . . . . . . . . . . : 100 MBps
Receive Only  . . . . . . . . . . . . . . : False
Multicast . . . . . . . . . . . . . . . . : True

Wireless80211 adapter WiFi
--------------------------
Description . . . . . . . . . . . . . . . : Marvell AVASTAR Wireless-AC Network Controller
Physical Address  . . . . . . . . . . . . : C46600551134
Operational status  . . . . . . . . . . . : Up
DNS Services  . . . . . . . . . . . . . . : dynamic
DNS Suffix  . . . . . . . . . . . . . . . : lan
DNS Servers . . . . . . . . . . . . . . . : fda1:aead:f7f0::1
                                          : 192.168.1.1
IPv4 DHCP Enabled . . . . . . . . . . . . : True
IPv4 MTU  . . . . . . . . . . . . . . . . : 1500
IPv6 MTU  . . . . . . . . . . . . . . . . : 1500
IPv6 Interface Index  . . . . . . . . . . : 11
Speed . . . . . . . . . . . . . . . . . . : 39 MBps
Receive Only  . . . . . . . . . . . . . . : False
Multicast . . . . . . . . . . . . . . . . : True

Loopback adapter Loopback Pseudo-Interface 1
--------------------------------------------
Description . . . . . . . . . . . . . . . : Software Loopback Interface 1
Physical Address  . . . . . . . . . . . . :
Operational status  . . . . . . . . . . . : Up
```




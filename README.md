# PTNADKeygen
After RSA key Replacement, just run the tool and enjoy ! :)

Setup:

1) Edit RSA Public keys with ours at `/opt/ptsecurity/nad/app/core/conf/settings/config.py` line 442 with the one you'll find at `/opt/ptsecurity/nad/app/updates/tests/test_api/test_license.py` (i used those keys just because it was more comfortable)

2) Build the tool with `dotnet build` (*pay attention, you need dotnet installed and better be 6+*)

3) Run tool and use the JWT keygenned

4) Profit!

Screen:

![image](https://user-images.githubusercontent.com/23401728/219508670-4a68028f-f1d0-452e-9b99-33167958e638.png)

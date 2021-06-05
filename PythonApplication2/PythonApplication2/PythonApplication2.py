import smtplib
import sys
import datetime
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText

if(len(sys.argv)!=1):
    email=sys.argv[1]
    subject=sys.argv[2] 

    credentials = ["DenysS@univ.net.ua","3231616Denis"]

    smtpObj = smtplib.SMTP('mail.univ.net.ua', 25)
    smtpObj.starttls()
    smtpObj.login(credentials[0],credentials[1])


    msg = MIMEMultipart()
    msg['From'] = credentials[0]
    msg['To'] = email
    msg['Subject'] = subject
    
    body = f"{datetime.datetime.now()} Sytnychenko Denys"
    msg.attach(MIMEText(body, 'plain'))




    smtpObj.sendmail(credentials[0],email,msg.as_string())
    smtpObj.quit()
else:
    print("Help: \n python script4.py [ToEmail] [Subject]")


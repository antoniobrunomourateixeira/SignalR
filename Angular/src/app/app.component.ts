import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
// import { Message } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'ChatAngular';
  public nome: string = "";
  private hubConnection: HubConnection;
  // msgs: Message[] = [];

  ngOnInit() {
    let builder = new HubConnectionBuilder();

    this.hubConnection = builder.withUrl('https://localhost:44346/chatHub').build();

    this.hubConnection.start();

    console.log(this.hubConnection);

    this.hubConnection.on('SendNotification', (type: string, message: string) => {
      // this.msgs.push({ severity: type, summary: message });
      this.nome = message;
    });

  }
}

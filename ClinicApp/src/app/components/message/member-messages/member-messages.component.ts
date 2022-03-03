import { Component, Input, OnInit, Output, Pipe, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/models/member';
import { Message } from 'src/app/models/message';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-member-messages',
  templateUrl: './member-messages.component.html',
  styleUrls: ['./member-messages.component.scss']
})
export class MemberMessagesComponent implements OnInit {
  @ViewChild('messageForm') messageForm!: NgForm;
  @Input() userName!: any;
  messages: Message[] = [];
  messages$!: Observable<Message[]>;
  member!:Member;
  messageContent!: string;


  constructor(private messageService: MessageService) {}

  ngOnInit(): void {
    this.loadMessages();
  }

  loadMessages() {
    this.messages$ = this.messageService.GetMessageThread(this.userName);
    console.log(this.messages$)
  }

  sendMessage(){
    this.messageService.SendMessage(this.userName, this.messageContent).subscribe( message => {
      this.messages.push(message);
      this.messageForm.reset();
    })
  }

}

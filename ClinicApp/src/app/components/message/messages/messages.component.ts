import { Component, Input, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/models/member';
import { Message } from 'src/app/models/message';
import { Pagination } from 'src/app/models/Pagination';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {
@Input() messages!: Message[] | null;
pagination!: Pagination;
container = 'Inbox';
pageNumber = 1;
pageSize = 6;
member!: Member;
length!: number;

  constructor(private messageService: MessageService,) {
     }

  ngOnInit(): void {
    this.loadMessages();
  }

  loadMessages(){
    this.messageService.getMessages(this.pageNumber, this.pageSize, this.container).subscribe(response => {
      this.messages = response.result;
      console.log(this.messages);
      this.pagination = response.pagination;
    })
  }

  pageChanged(event :any){
    this.pageNumber = event.page;
    this.loadMessages();
  }
}

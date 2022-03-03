export interface Message{
  id: number;
  senderID: number;
  senderName: string;
  senderLastName: string;
  senderUserName: string;
  senderPhotoUrl: string;
  recipientID: number;
  recipientUserName: string;
  recipientPhotoUrl: string;
  content: string;
  dateRead?: Date;
  messageSent: Date;
}

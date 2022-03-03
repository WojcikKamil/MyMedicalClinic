import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { SymptomDetailsModalComponent } from 'src/app/modals/symptom-modals/symptom-details-modal/symptom-details-modal.component';
import { Symptom } from 'src/app/models/symptom';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';
import { SymptomService } from 'src/app/services/symptom.service';

@Component({
  selector: 'app-symptom-active-requests',
  templateUrl: './symptom-active-requests.component.html',
  styleUrls: ['./symptom-active-requests.component.scss']
})
export class SymptomActiveRequestsComponent implements OnInit {
  symptoms: Partial<Symptom[]> | any;
  symptom$!: Observable<Symptom[]>;
  user!: User;
  bsModalRef!: BsModalRef;
  count!: string;

  constructor(
    private symptomService: SymptomService,
    private accountService: AccountService,
    private modalService: BsModalService,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    this.getRequests();
  }

  getRequests(){
    this.symptom$ = this.symptomService.getActiveSymptomRequest();
    }

    openSymptom(symptom: Symptom){
      const config = {
        class: 'modal-dialog-centered modal-lg',
        initialState: {
          symptom,
        }
      }
      this.bsModalRef = this.modalService.show(SymptomDetailsModalComponent, config);
    }
}

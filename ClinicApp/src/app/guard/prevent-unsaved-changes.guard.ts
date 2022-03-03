import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { DoctorEditComponent } from '../components/doctor/doctor-edit/doctor-edit.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesGuard implements CanDeactivate<unknown> {
  canDeactivate(component: DoctorEditComponent):boolean{
    if (component.editForm.dirty){
      return confirm('Are you sure you want to continue? Any unsaved changes will be lost')
    }
    return true;
  }
  }



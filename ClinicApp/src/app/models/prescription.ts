export interface Prescription{
  id: number;
  doctorEmail: string;
  patientEmail: string;
  patientName: string;
  patientLastName: string;
  patientPesel: string;
  doctorName: string;
  doctorLastName: string;
  medicines: string;
  dose: string;
  specialization: string;
  content: string;
  status: string;
  prescriptionRequestSent: Date;
  prescriptionAccepted: Date;
}

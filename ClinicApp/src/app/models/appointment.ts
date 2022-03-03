export interface Appointment{
  id: number;
  doctorEmail: string;
  patientEmail: string;
  patientName: string;
  patientLastName: string;
  patientPesel: string;
  doctorName: string;
  doctorLastName: string;
  doctorSpecialization: string;
  reason: string;
  diagnosis: string;
  recommendation: string;
  medicines: string;
  dose: string;
  recommendedDose: string;
  appointmentDate: Date;
}

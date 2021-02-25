Public Class GMK_LEVEL2_TOSTATRICI
    Structure strTelToPlc_1x_SilosDaScaricare
        Dim dataOraInvio As DateTime
        Dim sync1 As Int16
        Dim sync2 As Int16
        Dim sync As Int16
        Dim idRichiesta As Int32
        Dim tostatriceNr As Int16
        Dim ricettaNr As Int16
        Dim combinazioneBilance As Int16
        Dim SingoloSilos As Boolean
        Dim SilosMultipli As Boolean
        Dim FineRicetta As Boolean
        Dim silosPrelievo As Int16
        Dim codiceProdotto As Int16
        Dim pesoDaPrelevare As Single
        Dim tolleranzaPeso As Single
        Dim lotto As String
        Dim indice_componente As Int16
    End Structure
    Structure strTelFromPlc_1X_RichiestaSilosPerBilanciaX
        Dim dataOraRicezione As DateTime
        Dim sync1 As Int16
        Dim sync2 As Int16
        Dim sync As Int16
        Dim replyId As Int16
        Dim idRichiesta As Int32
        Dim tostatriceNr As Int16
        Dim ricettaNr As Int16
        Dim combinazioneBilance As Int16
        Dim sequenzaRichiesta As Int16
        Dim pesoAttualeBilancia As Single
        Dim ultimoSilosScaricato As Int16
        Dim erroreCiclo As Int16
        Dim silosVuoto As Int16
        Dim lotto As String
        Dim cicloNumero As Int16
        Dim cicliTotali As Int16
        Dim destinazioneEI As Int16
        Dim idTostatura As Int32
        Dim indice_componente As Int16
    End Structure
End Class

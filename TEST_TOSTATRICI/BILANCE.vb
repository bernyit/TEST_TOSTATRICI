Public Class BILANCE

    Enum enuBilance
        B1_OBBLIGATORIA = 0
        B2_OBBLIGATORIA = 1
        B3_OBBLIGATORIA = 2
        B4_OBBLIGATORIA = 3
        B5_OBBLIGATORIA = 4
        FL_OBBLIGATORIA = 5
        B1_OPZIONALE = 8
        B2_OPZIONALE = 9
        B3_OPZIONALE = 10
        B4_OPZIONALE = 11
        B5_OPZIONALE = 12
    End Enum

    Structure strSelezioneBilance
        Dim selezioneB1 As UInt16
        Dim selezioneB2 As UInt16
        Dim selezioneB3 As UInt16
        Dim selezioneB4 As UInt16
        Dim selezioneB5 As UInt16
        Dim spare1 As UInt16
        Dim spare2 As UInt16
        Dim selezioneFL As UInt16
    End Structure


    Public Shared Function spacchettaSelezione(ByVal combinazioneBilance As UInt16)

        Dim result As strSelezioneBilance

        result.selezioneB1 = combinazioneBilance And 1
        result.selezioneB2 = combinazioneBilance And 2
        result.selezioneB3 = combinazioneBilance And 4
        result.selezioneB4 = combinazioneBilance And 8
        result.selezioneB5 = combinazioneBilance And 16
        result.spare1 = combinazioneBilance And 32
        result.spare2 = combinazioneBilance And 64
        result.selezioneFL = combinazioneBilance And 128


        Return result
    End Function

    Public Shared Function bitBilancia(ByVal bilancia As enuBilance)

        Dim mask As UInt16 = 1 << bilancia

        Return mask
    End Function

    Public Shared Function combinazioneFattibileColor(ByVal bilancia As enuBilance, ByVal wordCombinazioni As UInt16) As Color

        Dim combinazioneOK As Color = Color.Gray

        Dim auxword As UInt16 = bitBilancia(bilancia)

        If (auxword And wordCombinazioni) > 0 Then
            combinazioneOK = Color.LightGreen
        End If


        Return combinazioneOK
    End Function

End Class

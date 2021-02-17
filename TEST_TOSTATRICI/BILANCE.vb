Public Class BILANCE


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

End Class

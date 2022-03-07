<!--<?xml version="1.0" encoding="utf-8"?>-->

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="xml" indent="yes"/>
	<xsl:template match="@* | node()">
		
        <table class="table">

		<tr style ="background-color: #C0C0C0">
			<td style=" border: thin double #800000"> Pais </td>
			<td style=" border: thin double #800000"> Ciudad </td>
		</tr>
		
		<xsl:for-each select="Root/Pronostico_Tiempo">
			<tr>
				<td>
					<xsl:value-of select="Pais" />
				</td>
				<td>
					<xsl:value-of select="Ciudad" />
				</td>
				<td>
					<xsl:value-of select="Pronostico_Hora" />

					<xsl:for-each select="Root/Pronostico_Tiempo/Pronostico_hora">
						
					    <table class="table">
						    <tr style ="background-color: #C0C0C0">
                                <td style=" border: thin double #800000"> Hora </td>
                                <td style=" border: thin double #800000"> Temperatura Máxima </td>
                                <td style=" border: thin double #800000"> Temperatura Mínima </td>
                                <td style=" border: thin double #800000"> Velocidad Viento </td>
                                <td style=" border: thin double #800000"> Probabilidad Lluvias </td>
                                <td style=" border: thin double #800000"> Probabilidad Tormentas </td>
                            </tr>

                        
                            <tr>
                                <td>
                                <xsl:value-of select="Tipo" />
                                </td>
                                <td>
                                <xsl:value-of select="Anio" />
                                </td>
                                <td>
                                <xsl:value-of select="Cantidad" />
                                </td>
                                <td style="background-color: #CCFFFF">
                                <xsl:value-of select="MontoMov" />
                                </td>
                                <td style="background-color: #FFFF99">
                                <xsl:value-of select="TipoMov" />
                                </td>
                            </tr>
					    </table>
                    </xsl:for-each>
				</td>
			</tr>
		</xsl:for-each>	
    </table>

	</xsl:template>
</xsl:stylesheet>
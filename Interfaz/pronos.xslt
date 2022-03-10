<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="@* | node()">
        <!--<xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>-->

		<div class="table">
			<div class="row" style="background-color:#9b9b9b;height:57px;">
				<div class="col-6 label"> Pais </div>
				<div class="col-6 label"> Ciudad </div>
			</div>

			<xsl:for-each select="Pronostico_Tiempo | node()">

				<div class="row">
					<div class="col-6 pais" style="background-color:#CCCCCC;">
						<div style="padding-top:2%;">
							<xsl:value-of select="Pais" />
						</div>
					</div>
					<div class="col-6 ciudad" style="background-color:#CCCCCC;">
						<div style="padding-top:2%;">
							<xsl:value-of select="Ciudad" />
						</div>
					</div>
					<div class="col-12 hora" style="background-color:white;border-width:1px;border-style:solid;text-align:left;">
						<xsl:for-each select="Root/Pronostico_Tiempo/Pronostico_Hora  | node()">						
							<div class="row">
								<div class="col-12 label" style="background-color:#FFFFCC">
									<xsl:value-of select="Hora" />
								</div>
							</div>
							<div class="row">
								<div class="col-2 label" style="margin-top:15px;font-weight:bold;">
									<xsl:value-of select="Temp_Max" />
								</div>
								<div class="col-2 label" style="margin-top:15px;font-weight:bold;">
									<xsl:value-of select="Temp_Min" />
								</div>
							</div>
							<div class="row">
								<div class="col-2 label">
									<xsl:value-of select="Prob_Lluvias" />
								</div>
								<div class="col-2 label">
									<xsl:value-of select="Prob_Tormenta" />
								</div>
							</div>
							<div class="row">
								<div class="col-2 label">
									<xsl:value-of select="Velo_Viento" />
								</div>
								<div class="col-2 label">
									<xsl:value-of select="Tipo_Cielo" />
								</div>
							</div>
						</xsl:for-each>
					</div>
				</div>

			</xsl:for-each>
		</div>
		
    </xsl:template>
</xsl:stylesheet>

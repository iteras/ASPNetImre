<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
      <html>
        <head>
          <title>
            <H1>Posts by persons</H1>
          </title>
        </head>
        <body>
          <H1>Posts by Persons</H1>
          <ul>
            <xsl:for-each select="/System/Person">
              <li>
                <xsl:value-of select="PersonData/UserName"/>
                <ul>
                  <xsl:for-each select="Posts">
                    <li>
                      <xsl:value-of select="PostTitle"/>
                      <p>
                        <xsl:value-of select="PostContent/PostDescription"/>
                      </p>
                     
                      <ul>

                        <xsl:for-each select="PostContent/PostPictures/Picture">
                          <li>
                            <xsl:value-of select="."/>
                          </li>
                        </xsl:for-each>
                      </ul>
                    </li>
                  </xsl:for-each>
                </ul>
              </li>
            </xsl:for-each>
          </ul>
        </body>
      </html>
      
    </xsl:template>
</xsl:stylesheet>
